using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Utils
{
    public class SpriteRendererOrderInLayer : MonoBehaviour
    {
        [SerializeField] private bool runOnce;

        private SpriteRenderer _spriteRenderer;
        private Transform _cachedTransform;
        private float _offsetY;
        private float _precisionMultiplier = 10f;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _cachedTransform = GetComponent<Transform>();
            _offsetY = _offsetY != 0 ? _cachedTransform.position.y * -1 - 0.2f : 0;
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
