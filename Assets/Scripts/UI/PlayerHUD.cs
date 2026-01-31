using System;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField]
        private ProgressBar _statusProgressBar;
        
        [SerializeField]
        private ProgressBar _suspectProgressBar;

        [SerializeField] 
        private PlayerDataBehavior _playerData;

        private void Start()
        {
            _playerData.OnStatusChanged += UpdateStatus;
            _playerData.OnSuspicionChanged += UpdateSuspicion;
            
            UpdateStatus(0, _playerData.Status);
            UpdateStatus(0, _playerData.Suspicion);
        }

        private void UpdateStatus(int change, int total)
        {
            _statusProgressBar.SetProgress(_playerData.StatusPercentage);
        }

        private void UpdateSuspicion(int change, int total)
        {
            _suspectProgressBar.SetProgress(_playerData.SuspicionPercentage);
        }
    }
}