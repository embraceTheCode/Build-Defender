using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BuilderDefender.Buildings;
using BuilderDefender.Utils;

namespace BuilderDefender.BuildSystem
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager Instance {get; private set;}

        public event Action<BuildingTypeSO> OnSelectedBuildingChanged;

        //? Research about addressables
        [field: SerializeField] public BuildingTypeListSO buildingTypeList {get; private set;}

        private BuildingTypeSO _selectedBuilding;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if(_selectedBuilding == null) return;
                Instantiate(_selectedBuilding.prefab,Utilities.GetMousePosition(),Quaternion.identity);
            }
            else if(Input.GetMouseButtonDown(1))
            {
                _selectedBuilding = null;
            }
        }

        public void SetSelectedBuilding(BuildingTypeSO newBuilding)
        {
            _selectedBuilding = newBuilding;
            OnSelectedBuildingChanged?.Invoke(newBuilding);
        }

        public BuildingTypeSO GetSelectedBuilding()
        {
            return _selectedBuilding;
        }
    }
}
