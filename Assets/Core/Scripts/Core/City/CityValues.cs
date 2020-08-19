﻿using UnityEngine;
using UnityEngine.Events;

namespace Core.City
{
    public class CityValues : MonoBehaviour
    {
        static CityValues s_CityValues;


        [SerializeField] int _cityLife = 3;

        UnityEvent _cityDestroyedEvent = new UnityEvent();

        public UnityEvent CityDestroyedEvent { get => _cityDestroyedEvent; }

        #region Unity Messages
        private void Awake()
        {
            CreateSingleton();
        }

        private void Start()
        {
            CityGate.StaticReference.EnemyEnteredGateEvent.AddListener(OnEnemyEntered);
        }


        private void OnDestroy()
        {
            DestroySingleton();
        }
        #endregion

        #region SingletonHandling
        private void CreateSingleton()
        {
            if (!s_CityValues)
            {
                s_CityValues = this;
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        private void DestroySingleton()
        {
            if (s_CityValues == this)
            {
                s_CityValues = null;
            }
        }
        #endregion


        private void OnEnemyEntered()
        {
            DecreaseCityLife();
        }

        void DecreaseCityLife()
        {
            _cityLife -= 1;
            CheckCityLife();
        }

        void CheckCityLife()
        {
            if (_cityLife <= 0)
            {
                _cityDestroyedEvent.Invoke();
                CityGate.StaticReference.EnemyEnteredGateEvent.RemoveListener(OnEnemyEntered);
            }
        }
    }

}
