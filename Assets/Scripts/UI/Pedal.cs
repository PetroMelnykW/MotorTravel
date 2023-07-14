using Events;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float DEFAULT_Z_ROTATION = 180;

    [Range(0f, 90f)]
    [SerializeField] private float _pressedRotation = 20f;

    private event System.Action<bool> _buttonAction;
    private bool _endGame = false;

    public void Subscribe(System.Action<bool> action)
    {
        _buttonAction += action;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_endGame) {
            return;
        }
        transform.localRotation = Quaternion.Euler(_pressedRotation, 0, DEFAULT_Z_ROTATION);
        _buttonAction?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_endGame) {
            return;
        }
        transform.localRotation = Quaternion.Euler(0, 0, DEFAULT_Z_ROTATION);
        _buttonAction?.Invoke(false);
    }

    private void Awake()
    {
        Observer.Subscribe<EndGameEvent>(OnEndGameEvent);
    }

    private void OnDestroy()
    {
        Observer.Unsubscribe<EndGameEvent>(OnEndGameEvent);
    }

    private void OnEndGameEvent(object sender, EndGameEvent eventData)
    {
        _endGame = true;
        transform.localRotation = Quaternion.Euler(0, 0, DEFAULT_Z_ROTATION);
    }
}
