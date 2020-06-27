namespace Game.Assets.Scripts.GamePlay
{
    using System;
    using Game.Assets.Scripts.Menu;
    using Game.Assets.Scripts.UI;
    using global::GamePlay;
    using global::GamePlay.Data;
    using UnityEngine;

    public class GamePlayController : MonoBehaviour, TimeControllerListener, WaveSpawnerListener,
     MapControllerListener, RetryListener, StartBattleListener, EnemyListener, HealthListener, ShopButtonListener,
      SpotListener, ShopBuyListener, ShopWindowListener
    {

        [SerializeField]
        private AudioSource _waveStartSound;

        [SerializeField]
        private AudioSource _waveEndSound;

        [SerializeField]
        private TurretSpotSelector _spotSelector;

        [SerializeField]
        private TurretSpawner _turretSpawner;

        [SerializeField]
        private HealthController _healthController;

        [SerializeField]
        private MoneyController _moneyController;

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
        private LoseWindow _loseWindow;

        [SerializeField]
        private ShopWindow _shopWindow;

        [SerializeField]
        private ShopButton _shopButton;

        [SerializeField]
        private TurretSpotsController _turretSpotsController;

        [SerializeField]
        private GamePlayData _gamePlay;

        private WavesController _wavesController;

        private GameState _gameState;

        private void Start()
        {
            _wavesController = new WavesController(_gamePlay.WavesData.Waves);
            InitializeHealthController();
            InitializeMoneyController();
            InitializeTimer();
            InitializeTuretSpotsController();
            InitializeWaveSpawner();
            InitializeMapController();
            InitializeWinWindow();
            InitializeStartWindow();
            InitializeLoseWindow();
            InitializeShopWindow();
            ShowStartWindow();
        }

        private void InitializeTowerSpawner()
        {
            _turretSpawner.Restart();
            _turretSpotsController.Restart();
        }

        private void InitializeTuretSpotsController()
        {
            _turretSpotsController.Initialize(this);
            _turretSpawner.Restart();
        }

        private void InitializeHealthController()
        {
            _healthController.Listener = this;
        }

        private void InitializeLoseWindow()
        {
            _loseWindow.Listener = this;
        }

        private void InitializeMoneyController()
        {
            _moneyController.AddMoney(_gamePlay.Player.Money.MoneyAtStart);
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

        private void InitializeShopWindow()
        {
            _shopButton.Listener = this;
            _shopWindow.Initialize(_gamePlay.TowerData.Towers, this);
            _shopWindow.Listener = this;
        }

        private void ShowStartWindow()
        {
            _startWindow.gameObject.SetActive(true);
        }

        public void AddMoney()
        {
            _moneyController.AddMoney(_gamePlay.Player.Money.MoneyPerSecond);
        }

        public void StartWave()
        {
            _userInterface.HideShop();
            WaveData waveData = _wavesController.GetWave();
            if (waveData != null)
            {
                if (_waveStartSound != null)
                {
                    _waveStartSound.Play();
                }
                _turretSpawner.TowerToSpawn = null;
                _waveSpawner.StartWave(waveData, this);
            }
        }

        public void OnAllEnemieSpawned()
        {
            _mapController.WaveState = WaveState.END;
        }

        public void OnEnemiesDisapear()
        {
            if (_gameState == GameState.IDLE)
            {
                if (_waveEndSound != null)
                {
                    _waveStartSound.Play();
                }

                if (_wavesController.AnyWaveLeft())
                {
                    StartBuildingMode();
                }
                else
                {
                    ShowWinWindow();
                }
            }
        }

        private void ShowWinWindow()
        {
            _gameState = GameState.WIN;
            StopGame();
            _winWindow.gameObject.SetActive(true);
        }

        private void StopGame()
        {
            _timeController.Pause();
        }

        private void StartBuildingMode()
        {
            _userInterface.ShowShop();
            _timeController.CountBuildingTime();
        }

        public void Retry()
        {
            _gameState = GameState.IDLE;
            _turretSpotsController.Restart();
            _turretSpawner.Restart();
            _healthController.Restart(_gamePlay.Player.StartHealth);
            _moneyController.Restart(_gamePlay.Player.Money.MoneyAtStart);
            _userInterface.Restart();
            _timeController.Restart();
            _wavesController.Restart();
        }

        public void StartBattle()
        {
            _timeController.Resume();
        }

        public void OnEnemyDead(int money)
        {
            if (_gameState == GameState.IDLE)
            {
                _moneyController.AddMoney(money);
            }
        }

        public void OnPlayerDead()
        {
            _gameState = GameState.LOSE;
            StopGame();
            _loseWindow.gameObject.SetActive(true);
        }

        public void DoDamage(int damage)
        {
            _healthController.OnDamageReceived(damage);
        }

        public void ShowShopWindow()
        {
            _spotSelector.Disable();
            _shopWindow.RefreshList(_moneyController.Money);
            _shopWindow.gameObject.SetActive(true);
        }

        public void OnSpotSelected(TurretSpot spot)
        {
            TowerData data = _turretSpawner.TowerToSpawn;
            Debug.Log("Spot selected " + data);
            if (data != null && !spot.IsSelected)
            {
                Debug.Log("Building tower");
                _moneyController.SubstractMoney(data.Price);
                spot.IsSelected = true;
                _turretSpawner.SpawnTower(spot.gameObject);
                _turretSpawner.TowerToSpawn = null;
            }

        }

        public void OnTowerBuyClicked(TowerData tower)
        {
            _turretSpawner.TowerToSpawn = tower;
            _spotSelector.Enable();
            _shopWindow.gameObject.SetActive(false);
        }

        public void OnCloseShopWindow()
        {
            _spotSelector.Enable();
        }
    }
}
