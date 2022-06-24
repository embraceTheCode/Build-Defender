using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BuilderDefender.BuildSystem;

namespace BuilderDefender.Buildings
{
    public class BuildingsUI : MonoBehaviour
    {
        [SerializeField] private Transform buildingUITemplate;

        [SerializeField]
        [Tooltip("The distance between each UI element, negative to move left or postive to move right")]
        private float xOffsetDistance;

        [SerializeField]
        private List<BuildingTypeSO> buildingIgnoreList;

        private Dictionary<BuildingTypeSO,BuildingUIDataHolder> _buildingTypeUIDataDictionary = new Dictionary<BuildingTypeSO, BuildingUIDataHolder>();
        private BuildingTypeListSO _buildingTypeList;

        private void Awake()
        {
            buildingUITemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            BuildManager.Instance.OnSelectedBuildingChanged += UpdateSelectedBuilding;

            _buildingTypeList = BuildManager.Instance.buildingTypeList;

            for (int i = 0; i < _buildingTypeList.buildings.Length; i++)
            {
                BuildingTypeSO currentBuilding = _buildingTypeList.buildings[i];
                if(buildingIgnoreList.Contains(currentBuilding)) continue;

                Transform newBuildingUI = Instantiate(buildingUITemplate,transform);
                newBuildingUI.gameObject.SetActive(true);

                newBuildingUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * xOffsetDistance, 0);

                BuildingUIDataHolder buildingUIData = newBuildingUI.GetComponent<BuildingUIDataHolder>();
                buildingUIData.image.sprite = currentBuilding.icon;

                newBuildingUI.GetComponent<Button>().onClick.AddListener( () => 
                {
                    BuildManager.Instance.SetSelectedBuilding(currentBuilding);
                });
                _buildingTypeUIDataDictionary[currentBuilding] = buildingUIData;
            }
        }

        private void UpdateSelectedBuilding(BuildingTypeSO newSelectedBuilding)
        {
            BuildingTypeSO previousBuilding = BuildManager.Instance.GetSelectedBuilding();
            if(previousBuilding != null)
            {
                BuildingUIDataHolder previousBuildingData = _buildingTypeUIDataDictionary[previousBuilding];
                previousBuildingData.selectedIndicator.gameObject.SetActive(false);
            }
            if(newSelectedBuilding != null) 
            {
                BuildingUIDataHolder currentBuildingData = _buildingTypeUIDataDictionary[newSelectedBuilding];
                currentBuildingData.selectedIndicator.gameObject.SetActive(true);
            }
        }
    }
}
