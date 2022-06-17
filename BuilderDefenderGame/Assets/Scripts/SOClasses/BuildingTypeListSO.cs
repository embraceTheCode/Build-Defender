using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Buildings
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BuildingList")]
    public class BuildingTypeListSO : ScriptableObject
    {
        public BuildingTypeSO[] buildings;
    }
}
