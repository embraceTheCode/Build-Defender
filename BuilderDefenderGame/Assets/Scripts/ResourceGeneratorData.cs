using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Resources
{
    [System.Serializable]
    public struct ResourceGeneratorData
    {
        public float timerMax;
        public ResourceTypeSO resourceType;
        public float amountGainedPerNode;
        public float nodeDetectionRadius;
        public float maxTotalAmountGained;
        
    }
}
