using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuGameManager : MonoBehaviour
{
    //Singlton
    private static MainMenuGameManager _instance;

    public static int Coins {
        get {
            return _instance.PlayerData.Coins;
        }
        set {
            _instance.PlayerData.Coins = value;
            _instance.UpdateUI();
        }
    }

    public static int Energy {
        get {
            return _instance.PlayerData.Energy;
        }
        set {
            _instance.PlayerData.Energy = value;
            _instance.UpdateUI();
        }
    }

    //Object
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _addEnergyButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _vehiclesButton;
    [SerializeField] private GameObject _settingsWindow;
    

    public PlayerData PlayerData => _playerData;

    public void UpdateUI()
    {
        _coinsText.text = _playerData.Coins.ToString();
        _energyText.text = _playerData.Energy.ToString();
    }

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
        UpdateUI();
        _addCoinsButton.onClick.AddListener(OnAddCoinsButtonClick);
        _addEnergyButton.onClick.AddListener(OnAddEnergyButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _shopButton.onClick.AddListener(OnShopButtonClick);
        _vehiclesButton.onClick.AddListener(OnVehiclesButtonClick);
    }

    private void OnAddCoinsButtonClick()
    {
        Coins += 1;
    }

    private void OnAddEnergyButtonClick()
    {
        Energy += 1;
    }

    private void OnSettingsButtonClick()
    {
        if (_settingsWindow != null) {
            _settingsWindow.SetActive(!_settingsWindow.activeSelf);
        }
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void OnShopButtonClick() { }

    private void OnVehiclesButtonClick() { }
}
