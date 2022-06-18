using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Buildings;

namespace BuilderDefender.BuildSystem
{
    public class BuildManager : MonoBehaviour
    {
        //? Research about addressables to load the buildingTypeSO in order to have only 1 source of truth
        [SerializeField] BuildingTypeListSO buildingTypeList;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main.GetComponent<Camera>();   
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(gameObject,GetMousePosition(),Quaternion.identity);
            }
            else if(Input.GetMouseButtonDown(1))
            {
                //TODO: Deselect building
            }
        }

        private Vector2 GetMousePosition()
        {
            Vector2 mouseWorldPosition = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return mouseWorldPosition;
        }
    }
}
