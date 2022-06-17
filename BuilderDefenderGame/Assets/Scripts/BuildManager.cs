using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Buildings;

namespace BuilderDefender.BuildSystem
{
    public class BuildManager : MonoBehaviour
    {
        //? Research about addressables to load the buildingTypeSO
        [SerializeField] BuildingTypeListSO buildingTypeList;
        [SerializeField] Transform prefab; //! Only for testing, remove later

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main.GetComponent<Camera>();   
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(prefab,GetMousePosition(),Quaternion.identity);
            }
        }

        private Vector2 GetMousePosition()
        {
            Vector2 mouseWorldPosition = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return mouseWorldPosition;
        }
    }
}
