using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderDefender.Utils
{
    public static class Utilities
    {
        private static Camera mainCamera;

        public static Vector2 GetMousePosition()
        {
            if(mainCamera == null) mainCamera = Camera.main;

            Vector2 mouseWorldPosition = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return mouseWorldPosition;
        }
    }
}
