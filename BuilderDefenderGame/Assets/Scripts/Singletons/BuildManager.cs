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

        [SerializeField] private float maxConstructionRadius;

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
                if(!CanBuild(_selectedBuilding, Utilities.GetMousePosition())) return;

                Instantiate(_selectedBuilding.prefab,Utilities.GetMousePosition(),Quaternion.identity);
            }
            else if(Input.GetMouseButtonDown(1))
            {
                SetSelectedBuilding(null);                
            }
        }

        private bool CanBuild(BuildingTypeSO building, Vector3 position)
        {
            BoxCollider2D boxCollider = _selectedBuilding.prefab.GetComponent<BoxCollider2D>();

            Collider2D[] colliders = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider.offset, boxCollider.size, 0);

            bool isClear = colliders.Length == 0;
            if(!isClear) return false;

            //*Check if similar building is too close
            colliders = Physics2D.OverlapCircleAll(position, _selectedBuilding.minConstructionRadius);
            foreach(Collider2D collider in colliders)
            {
                BuildingTypeSO currentBuilding = collider.GetComponent<BuildingTypeHolder>().buildingType;
                if(currentBuilding == null) continue;
                if(currentBuilding == building) return false;
            }

            //*Check if there is another building near
            colliders = Physics2D.OverlapCircleAll(position, maxConstructionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<BuildingTypeHolder>() != null) return true;
            }

            return false;
        }

        public void SetSelectedBuilding(BuildingTypeSO newBuilding)
        {
            OnSelectedBuildingChanged?.Invoke(newBuilding);
            _selectedBuilding = newBuilding;
        }

        public BuildingTypeSO GetSelectedBuilding()
        {
            return _selectedBuilding;
        }
    }
}
