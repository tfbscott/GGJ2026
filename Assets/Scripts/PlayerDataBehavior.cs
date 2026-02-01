using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerDataBehavior : MonoBehaviour
    {
        [SerializeField] 
        private int _startingStatus;

        [SerializeField] 
        private int _maxStatus;

        [SerializeField] 
        private int _startingSuspicion;
        
        [SerializeField] 
        private int _maxSuspicion;

        private int _status;
        public int Status => _status;
        public float StatusPercentage => (float)_status / _maxStatus;
        
        private int _suspicion;
        public int Suspicion => _suspicion;
        public float SuspicionPercentage => (float)_suspicion / _maxSuspicion;

        public event Action<int, int> OnStatusChanged;
        public event Action<int, int> OnSuspicionChanged;

        private void Start()
        {
            _status = _startingStatus;
            _suspicion = _startingSuspicion;
            
            OnStatusChanged?.Invoke(0, _status);
            OnSuspicionChanged?.Invoke(0, _suspicion);
        }

        public void UpdateValues(int statusDelta, int suspicionDelta)
        {
            _status += statusDelta;
            _suspicion += suspicionDelta;
            if (statusDelta != 0)
            {
                OnStatusChanged?.Invoke(statusDelta, _status);
            }
            if (suspicionDelta != 0)
            {
                OnSuspicionChanged?.Invoke(suspicionDelta, _suspicion);
            }
        }
    }
}