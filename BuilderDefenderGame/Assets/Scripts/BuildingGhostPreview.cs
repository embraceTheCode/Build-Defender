using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuilderDefender.Buildings;
using BuilderDefender.Utils;

namespace BuilderDefender.BuildSystem
{
    public class BuildingGhostPreview : MonoBehaviour
    {
        [SerializeField] private GameObject ghostPreview;
        private SpriteRenderer _ghostSprite;
        private Transform _cachedTransform;

        private void Awake()
        {
            _ghostSprite = ghostPreview.GetComponent<SpriteRenderer>();
            _cachedTransform = GetComponent<Transform>();
            Hide();
        }

        private void Start()
        {
            BuildManager.Instance.OnSelectedBuildingChanged += BuildManager_OnSelectedBuildingChanged;
        }

        private void Update()
        {
            _cachedTransform.position = Utilities.GetMousePosition();
        }

        private void BuildManager_OnSelectedBuildingChanged(BuildingTypeSO building)
        {
            if(building != null)
            {
                Show(building.ghostImage);
            }
            else
            {
                Hide();
            }
        }

        private void Show(Sprite sprite)
        {
            _ghostSprite.sprite = sprite;
            ghostPreview.SetActive(true);
        }

        private void Hide()
        {
            ghostPreview.SetActive(false);
        }
    }
}
