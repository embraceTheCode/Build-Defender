using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BuilderDefender.ResourceSystem;

namespace BuilderDefender.Resources
{
    public class ResourcesUI : MonoBehaviour
    {
        [SerializeField] private Transform resourceUITemplate;

        [SerializeField]
        [Tooltip("The distance between each UI element, negative to move left or postive to move right")]
        private float xOffsetDistance;
        
        private Dictionary<ResourceTypeSO,ResourceUIDataHolder> _resourceTypeUIDataDictionary = new Dictionary<ResourceTypeSO, ResourceUIDataHolder>();

        private ResourceTypeListSO _resourceTypeList;

        private void Awake()
        {
            resourceUITemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            ResourceManager.Instance.OnResourceAmountChange += ResourceManager_OnResourceAmountChange;

            _resourceTypeList = ResourceManager.Instance.resourceTypeList;

            for (int i = 0; i < _resourceTypeList.resources.Length; i++)
            {
                ResourceTypeSO currentResource = _resourceTypeList.resources[i];

                Transform newResourceUI = Instantiate(resourceUITemplate, transform);
                newResourceUI.gameObject.SetActive(true);

                newResourceUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * xOffsetDistance, 0);

                ResourceUIDataHolder resourceUIData = newResourceUI.GetComponent<ResourceUIDataHolder>();
                resourceUIData.image.sprite = currentResource.sprite;
                _resourceTypeUIDataDictionary[currentResource] = resourceUIData;
            }

            UpdateResourceAmount();
        }

        private void OnDisable() => ResourceManager.Instance.OnResourceAmountChange -= ResourceManager_OnResourceAmountChange;

        private void ResourceManager_OnResourceAmountChange() => UpdateResourceAmount();
        
        private void UpdateResourceAmount()
        {
            foreach(ResourceTypeSO currentResource in _resourceTypeList.resources)
            {
                int amount = ResourceManager.Instance.GetResourceAmount(currentResource);
                ResourceUIDataHolder resourceUIData = _resourceTypeUIDataDictionary[currentResource];
                resourceUIData.text.SetText(amount.ToString());
            }
        }
    }
}
