using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Events;

public class EndGameManager : MonoBehaviour
{
    //Singlton
    private static EndGameManager _instance;

    public static void EndGame()
    {
        _instance.SaveData();
        _instance.UpdateUI();
        Observer.Post(_instance, new EndGameEvent { });
    }

    //Object
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private TMP_Text _collectedCoinsText;
    [SerializeField] private TMP_Text _totalDistanceText;
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _retryButton;

    public void SaveData()
    {
        _playerData.Record = DistanceManager.Distance;
        _playerData.Coins += CoinsManager.Coins;
    }

    public void UpdateUI()
    {
        _collectedCoinsText.text = CoinsManager.Coins.ToString();
        _totalDistanceText.text = DistanceManager.Distance.ToString();
        _recordText.text = _playerData.Record.ToString();
        _endGameWindow.SetActive(true);
    }

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _retryButton.onClick.AddListener(OnRetryButtonClick);
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void OnRetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
