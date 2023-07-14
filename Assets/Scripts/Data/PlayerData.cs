using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    private const int MAX_ENERGY = 10;

    [SerializeField] private int _coins;
    [SerializeField] private int _energy;
    [SerializeField] private int _record;
    [SerializeField] private List<VehicleData> _vehicles;

    public int Coins {
        get { return _coins; }    
        set {
            if (value < 0) {
                Debug.LogError("Negative value of coins");
            }
            _coins = value;
        }
    }

    public int Energy {
        get { return _energy;}
        set {
            if (value < 0) {
                _energy = 0;
                Debug.LogError("Negative value of energy");
            }
            else if (value > MAX_ENERGY) {
                _energy = MAX_ENERGY;
            }
            else {
                _energy = value;
            }
        }
    }

    public int Record {
        get { return _record; }
        set {
            if (value > _record)
            {
                _record = value;
            }
        }
    }
}

[System.Serializable]
public class VehicleData
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _owned;

    public string Name => _name;
    public int Cost => _cost;
    public Sprite Sprite => _sprite;
    public GameObject Prefab => _prefab;
    public bool Owned { get { return _owned; } set { _owned = value; } }
}