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
        [SerializeField] private Transform resourceUITemplate;

        [SerializeField]
        [Tooltip("The distance between each UI element, negative to move left or postive to move right")]
        private float xOffsetDistance;

        [SerializeField]
        [Tooltip("The distance from the top for all UI elements, negative to move down or postive to move up")]
        private float yOffsetDistance;

        private Dictionary<ResourceTypeSO,ResourceUIDataHolder> _resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, ResourceUIDataHolder>();

        private ResourceTypeListSO resourceTypeList;

        private void Awake()
        {
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, yOffsetDistance);
        }

        private void Start()
        {
            ResourceManager.Instance.OnResourceAmountChange += ResourceManager_OnResourceAmountChange;

            resourceTypeList = ResourceManager.Instance.resourceTypeList;

            for (int i = 0; i < resourceTypeList.resources.Length; i++)
            {
                ResourceTypeSO currentResource = resourceTypeList.resources[i];

                Transform newResourceUI = Instantiate(resourceUITemplate, transform);
                newResourceUI.gameObject.SetActive(true);

                newResourceUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * xOffsetDistance, 0);

                ResourceUIDataHolder resourceUIData = newResourceUI.GetComponent<ResourceUIDataHolder>();
                resourceUIData.image.sprite = currentResource.sprite;
                _resourceTypeTransformDictionary[currentResource] = resourceUIData;
            }

            UpdateResourceAmount();
        }

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
                ResourceUIDataHolder resourceUIData = _resourceTypeTransformDictionary[currentResource];
                resourceUIData.text.SetText(amount.ToString());
            }
        }
    }
}
