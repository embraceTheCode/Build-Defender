using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BuilderDefender.Buildings;

namespace BuilderDefender.BuildSystem
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager Instance {get; private set;}

        //? Research about addressables
        [field: SerializeField] public BuildingTypeListSO buildingTypeList {get; private set;}

        private BuildingTypeSO _selectedBuilding;
        private Camera _mainCamera;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _mainCamera = Camera.main.GetComponent<Camera>();   
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if(_selectedBuilding == null) return;
                Instantiate(_selectedBuilding.prefab,GetMousePosition(),Quaternion.identity);
            }
            else if(Input.GetMouseButtonDown(1))
            {
                _selectedBuilding = null;
            }
        }

        private Vector2 GetMousePosition()
        {
            Vector2 mouseWorldPosition = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return mouseWorldPosition;
        }

        public void SetSelectedBuilding(BuildingTypeSO newBuilding)
        {
            _selectedBuilding = newBuilding;
        }

        public BuildingTypeSO GetSelectedBuilding()
        {
            return _selectedBuilding;
        }
    }
}
