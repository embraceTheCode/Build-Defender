using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Resources
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Resource")]
    public class ResourceTypeSO : ScriptableObject
    {
        public string resourceName;
        public Sprite sprite;
    }
}
