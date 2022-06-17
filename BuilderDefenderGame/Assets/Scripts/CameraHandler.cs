using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace BuilderDefender.CameraSystem
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [Header("Camera Move Settings")]
        [SerializeField] private float moveSpeed;

        [Header("Camera Zoom Settings")]
        [SerializeField] private float minimumZoomSize;
        [SerializeField] private float maximumZoomSize;
        [SerializeField] private float zoomStep;
        [SerializeField] private float zoomSpeed;

        private float _orthographicSize;
        private float _targetOrthographicSize;
        private Transform cachedTransform;

        private void Awake() => cachedTransform = GetComponent<Transform>();

        private void Update()
        {
            HandleMovement();
            HandleZoom();   
        }

        private void HandleMovement()
        {
            Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
            cachedTransform.position += movementInput.normalized * moveSpeed * Time.deltaTime;
        }

        private void HandleZoom()
        {
            _targetOrthographicSize += -Input.mouseScrollDelta.y * zoomStep;
            _targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, minimumZoomSize, maximumZoomSize);

            _orthographicSize = Mathf.Lerp(_orthographicSize,_targetOrthographicSize, Time.deltaTime * zoomSpeed);

            virtualCamera.m_Lens.OrthographicSize = _orthographicSize;
        }
    }
}
