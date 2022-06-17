using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Resources
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourceList")]
    public class ResourceTypeListSO : ScriptableObject
    {
        public ResourceTypeSO[] resources;
    }
}
