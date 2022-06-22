using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Resources;

namespace BuilderDefender.ResourceSystem
{
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance {get; private set;}

        public Action OnResourceAmountChange;

        [field: SerializeField] public ResourceTypeListSO resourceTypeList {get; private set;}

        private Dictionary<ResourceTypeSO, int> _resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        private void Awake()
        {
            Instance = this;

            foreach(ResourceTypeSO resource in resourceTypeList.resources)
            {
                _resourceAmountDictionary[resource] = 0;
            }   
        }
    
        public void AddResource(ResourceTypeSO resourceType, int amount)
        {
            _resourceAmountDictionary[resourceType] += amount;
            OnResourceAmountChange?.Invoke();
        }

        public int GetResourceAmount(ResourceTypeSO resourceType)
        {
            return _resourceAmountDictionary[resourceType];
        }
    }

}
