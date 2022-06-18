using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Resources;

namespace BuilderDefender.ResourceSystem
{
    public class ResourceGenerator : MonoBehaviour
    {
        [SerializeField] private ResourceGeneratorData _resourceGeneratorData;
        private float _timer;
        private float _timerMax;

        private void Awake()
        {
            _resourceGeneratorData = GetComponent<ResourceGeneratorData>();
            _timerMax = _resourceGeneratorData.timerMax;
            _timer = _timerMax;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                _timer += _timerMax;
                ResourceManager.Instance.AddResource(_resourceGeneratorData.resourceType, 1);
            }   
        }
    }
}
