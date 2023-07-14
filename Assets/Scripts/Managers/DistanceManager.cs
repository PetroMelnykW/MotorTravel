using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    //Singleton
    private static DistanceManager _instance;

    public static int Distance => _instance.distance > 0 ? _instance.distance : 0;

    //Object
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private Transform _playerTransform;

    [HideInInspector]
    public int distance = 0;

    private Vector3 _startPosition;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _startPosition = _playerTransform.position;
    }

    private void Update()
    {
        distance = (int)(_playerTransform.position.x - _startPosition.x);
        UpdateText();
    }

    private void UpdateText()
    {
        if (_distanceText != null) {
            _distanceText.text = $"{distance}m";
        }
    }
}
