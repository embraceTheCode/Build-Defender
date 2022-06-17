using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Buildings;

namespace BuilderDefender.ResourceSystem
{
    public class ResourceGenerator : MonoBehaviour
    {
        private BuildingTypeSO _buildingType;
        private float _timer;
        private float _timerMax;

        private void Awake()
        {
            _buildingType = GetComponent<BuildingTypeHolder>().buildingType;
            _timerMax = _buildingType.resourceGeneratorData.timerMax;
            _timer = _timerMax;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                _timer += _timerMax;
                ResourceManager.Instance.AddResource(_buildingType.resourceGeneratorData.resourceType, 1);
            }   
        }
    }
}
