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
        private float _amountGained;
        private float _maxTotalAmount;

        private void Awake()
        {
            _timerMax = _resourceGeneratorData.timerMax;
            _timer = _timerMax;
        }

        private void Start()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _resourceGeneratorData.nodeDetectionRadius);

            int nearbyResourceNodes = 0;
            foreach(Collider2D collider in colliders)
            {
                ResourceTypeHolder resourceType = collider.GetComponent<ResourceTypeHolder>();
                if(resourceType != null)
                {
                    if(resourceType.resource == _resourceGeneratorData.resourceType)
                    {
                        nearbyResourceNodes++;
                    }
                }
            }

            if(nearbyResourceNodes == 0) Destroy(this);

            _amountGained = _resourceGeneratorData.amountGainedPerNode * nearbyResourceNodes;
            _amountGained = Mathf.Clamp(_amountGained,0,_resourceGeneratorData.maxTotalAmountGained);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                _timer += _timerMax;
                ResourceManager.Instance.AddResource(_resourceGeneratorData.resourceType, (int) _amountGained);
            }   
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _resourceGeneratorData.nodeDetectionRadius);
        }
    }
}
