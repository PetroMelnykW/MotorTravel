using Events;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private Button _button;

    private void Awake()
    {
        Observer.Subscribe<EndGameEvent>(OnEndGameEvent);
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        Observer.Unsubscribe<EndGameEvent>(OnEndGameEvent);
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (_settingsWindow != null) {
            _settingsWindow.SetActive(!_settingsWindow.activeSelf);
        }
    }

    private void OnEndGameEvent(object sender, EndGameEvent eventData)
    {
        _button.interactable = false;
    }
}
