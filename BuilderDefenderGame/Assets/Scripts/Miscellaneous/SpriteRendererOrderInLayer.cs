using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Utils
{
    public class SpriteRendererOrderInLayer : MonoBehaviour
    {
        [SerializeField] private bool runOnce;
        [SerializeField] private float _offsetY;

        private SpriteRenderer _spriteRenderer;
        private Transform _cachedTransform;
        private float _precisionMultiplier = 10f;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _cachedTransform = GetComponent<Transform>();
            SetOrder();
            if(runOnce) Destroy(this);
        }

        private void LateUpdate()
        {
            SetOrder();
        }

        private void SetOrder()
        {
            _spriteRenderer.sortingOrder = (int)((_cachedTransform.position.y + _offsetY) * _precisionMultiplier * -1);
        }
    }
}
