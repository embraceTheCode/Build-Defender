using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Buildings
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Building")]
    public class BuildingTypeSO : ScriptableObject
    {
        public string buildingName;
        public Transform prefab;
        public Sprite icon;
    }
}
