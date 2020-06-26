using System;
using GamePlay;
using TMPro;
using UnityEngine;

namespace Game.Assets.Scripts.GamePlay
{
    public class TimeController : MonoBehaviour, GamePlay
    {

        [SerializeField]
        private GameObject _timerObject;

        [SerializeField]
        private TMP_Text timePlaceholder;

        private float _buildingTime = 10;

        private float _buildingRemainingTime;

        private int previousSecond = 0;

        private TimerType type = TimerType.BUILDING;

        private float _waveTime = 0f;

        private bool _pause = true;

        private TimeControllerListener _listener;

        private Vector3 _timerPosition;

        public TimeControllerListener Listener { set => _listener = value; }
        public float BuildingTime { set => _buildingTime = value; }

        private void Start()
        {
            _buildingRemainingTime = _buildingTime + 1;
            _timerPosition = _timerObject.transform.position;
        }

        public void Pause()
        {
            lock (this)
            {
                _pause = true;
            }
        }

        public void Resume()
        {
            lock (this)
            {
                _pause = false;
            }
        }


        void Update()
        {
            lock (this)
            {
                if (!_pause)
                {
                    switch (type)
                    {
                        case TimerType.BUILDING:
                            {
                                CountDownBuildingTime();
                                break;
                            }
                        case TimerType.WAVE:
                            {
                                CountWaveTime();
                                break;
                            }
                    }
                }
            }
        }

        private void CountWaveTime()
        {
            _waveTime += Time.deltaTime;
            int second = ((int)_waveTime);
            if (previousSecond != second)
            {
                if (_listener != null)
                {
                    _listener.AddMoney();
                }
            }
            this.previousSecond = second;
        }

        private void CountDownBuildingTime()
        {
            _buildingRemainingTime -= Time.deltaTime;
            int second = ((int)_buildingRemainingTime);
            timePlaceholder.text = second.ToString();
            if (_buildingRemainingTime <= 0f)
            {
                timePlaceholder.text = "0";
                OnWaveStarted();
            }
        }

        internal void Restart()
        {
            CountBuildingTime();
            Resume();
        }

        private void OnWaveStarted()
        {
            _waveTime = 0f;
            if (_listener != null)
            {
                _listener.StartWave();
                HideTimer();

            }
            type = TimerType.WAVE;
        }

        private void HideTimer()
        {
            _timerObject.transform.position = new Vector3(0f, 100f, 0f);
        }

        public void CountBuildingTime()
        {
            _buildingRemainingTime = _buildingTime + 1;
            ShowTimer();
            type = TimerType.BUILDING;
        }

        private void ShowTimer()
        {
            _timerObject.transform.position = _timerPosition;
        }
    }
}