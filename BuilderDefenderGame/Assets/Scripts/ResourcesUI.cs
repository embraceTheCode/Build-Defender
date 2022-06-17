using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BuilderDefender.Resources;
using BuilderDefender.ResourceSystem;

namespace BuilderDefender.UI
{
    public class ResourcesUI : MonoBehaviour
    {
        [SerializeField] private ResourceTypeListSO resourceTypeList;
        [SerializeField] private Transform resourceUITemplate;

        [SerializeField]
        [Tooltip("The distance between each UI element, negative to move left or postive to move right")]
        private float xOffsetDistance;

        private Dictionary<ResourceTypeSO,Transform> _resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        private void Awake()
        {
            resourceUITemplate.gameObject.SetActive(false);
            
            for(int i=0; i < resourceTypeList.resources.Length; i++)
            {
                ResourceTypeSO currentResource = resourceTypeList.resources[i];

                Transform newResourceUI = Instantiate(resourceUITemplate, transform);
                newResourceUI.gameObject.SetActive(true);

                newResourceUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(i*xOffsetDistance,0);

                //? Consider making a resourceUIData that holds the references to the image and tmp to not use this function
                newResourceUI.GetComponentInChildren<Image>().sprite = currentResource.sprite; 
                _resourceTypeTransformDictionary[currentResource] = newResourceUI;
            }
        }

        private void Start()
        {
            UpdateResourceAmount();
        }

        private void OnEnable() => ResourceManager.Instance.OnResourceAmountChange += ResourceManager_OnResourceAmountChange;

        private void OnDisable() => ResourceManager.Instance.OnResourceAmountChange -= ResourceManager_OnResourceAmountChange;

        private void ResourceManager_OnResourceAmountChange()
        {
            UpdateResourceAmount();
        }

        private void UpdateResourceAmount()
        {
            foreach(ResourceTypeSO currentResource in resourceTypeList.resources)
            {
                int amount = ResourceManager.Instance.GetResourceAmount(currentResource);
                Transform resourceUI = _resourceTypeTransformDictionary[currentResource];
                resourceUI.GetComponentInChildren<TextMeshProUGUI>().SetText(amount.ToString());
            }
        }
    }
}
