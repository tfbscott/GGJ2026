using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DisplayOnlyOnMobile : MonoBehaviour
    {
        private void Awake()
        {
            #if !UNITY_ANDROID
            gameObject.SetActive(false);
            #endif
        }
    }
}