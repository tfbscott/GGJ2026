using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] 
        private Image _maskImage;
        
        [SerializeField]
        private Image.FillMethod _fillMethod;

        private void Start()
        {
            _maskImage.type = Image.Type.Filled;
            _maskImage.fillMethod = _fillMethod;
        }

        public void SetProgress(float progress)
        {
            _maskImage.fillAmount = progress;
        }
    }
}