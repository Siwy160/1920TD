namespace Game.Assets.Scripts.GamePlay
{
    using System;
    using Game.Assets.Scripts.UI;
    using global::GamePlay;
    using global::GamePlay.Data;
    using UnityEngine;

    public class GamePlayController : MonoBehaviour, TimeControllerListener, WaveSpawnerListener, MapControllerListener, RetryListener, StartBattleListener
    {
        [SerializeField]
        private TimeController _timeController;

        [SerializeField]
        private WaveSpawner _waveSpawner;

        [SerializeField]
        private UserInterface _userInterface;

        [SerializeField]
        private MapController _mapController;

        [SerializeField]
        private WinWindow _winWindow;

        [SerializeField]
        private StartWindow _startWindow;

        [SerializeField]
        private GamePlayData _gamePlay;

        private WavesController _wavesController;

        private void Start()
        {
            _wavesController = new WavesController(_gamePlay.WavesData.Waves);
            InitializeTimer();
            InitializeWaveSpawner();
            InitializeMapController();
            InitializeWinWindow();
            InitializeStartWindow();
        }

        private void InitializeStartWindow()
        {
            _startWindow.Listener = this;
        }

        private void InitializeWinWindow()
        {
            _winWindow.Listener = this;
        }

        private void InitializeTimer()
        {
            _timeController.Listener = this;
            _timeController.BuildingTime = _gamePlay.TimerData.BuildingTime;
        }

        private void InitializeWaveSpawner()
        {
            _waveSpawner.Listener = this;
        }

        private void InitializeMapController()
        {
            _mapController.Listener = this;
        }

        public void AddMoney()
        {

        }

        public void StartWave()
        {
            _userInterface.HideShop();
            WaveData waveData = _wavesController.GetWave();
            if (waveData != null)
            {
                _waveSpawner.StartWave(waveData);
            }
        }

        public void OnAllEnemieSpawned()
        {
            _mapController.WaveState = WaveState.END;
        }

        public void OnEnemiesDisapear()
        {
            if (_wavesController.AnyWaveLeft())
            {
                StartBuildingMode();
            }
            else
            {
                ShowWinWindow();
            }
        }

        private void ShowWinWindow()
        {
            _winWindow.gameObject.SetActive(true);
        }

        private void StartBuildingMode()
        {
            _userInterface.ShowShop();
            _timeController.CountBuildingTime();
        }

        public void Retry()
        {
            _userInterface.Restart();
            _timeController.Restart();
            _wavesController.Restart();
        }

        public void StartBattle()
        {
            _timeController.Resume();
        }
    }
}
