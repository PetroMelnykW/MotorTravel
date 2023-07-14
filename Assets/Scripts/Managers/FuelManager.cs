using Events;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    private const float MAX_FUEL = 100f;

    //Singleton
    private static FuelManager _instance;
    
    public static void AddFuel(float value)
    {
        _instance.Fuel += value;
    }

    //Object
    [SerializeField] private Image _imageFill;
    [Range(1f, 5f)]
    [SerializeField] private float _drainSpeed = 1f;
    [SerializeField] private Gradient _fillGradient;

    private float _fuel = MAX_FUEL;
    private bool _endGame = false;

    public float Fuel {
        get { return _fuel; }
        private set {
            if (value > MAX_FUEL) {
                _fuel = MAX_FUEL;
            }
            else if (value <= 0) {
                _fuel = 0;
                EndGameManager.EndGame();
            }
            else {
                _fuel = value;
            }
            UpdateImageFill();
        }
    }

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
        Observer.Subscribe<EndGameEvent>(OnEndGameEvent);
    }

    private void OnDestroy()
    {
        Observer.Unsubscribe<EndGameEvent>(OnEndGameEvent);
    }

    private void Update()
    {
        if (_endGame) {
            return;
        }
        Fuel -= Time.deltaTime * _drainSpeed;
    }

    private void UpdateImageFill()
    {
        _imageFill.fillAmount = _fuel / MAX_FUEL;
        _imageFill.color = _fillGradient.Evaluate(_imageFill.fillAmount);
    }

    private void OnEndGameEvent(object sender, EndGameEvent eventData)
    {
        _endGame = true;
    }

}
