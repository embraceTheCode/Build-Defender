using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BuilderDefender.Buildings
{
    public class BuildingUIDataHolder : MonoBehaviour
    {
        public Image image;
        public Image selectedIndicator;

        private void Awake()
        {
            selectedIndicator.gameObject.SetActive(false);
        }
    }
}
