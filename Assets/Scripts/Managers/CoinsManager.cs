using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    //Singlton
    private static CoinsManager _instance;

    public static int Coins {
        get { return _instance.coins; }
        private set {
            _instance.coins = value;
            _instance.UpdateText();
        }
    }

    public static void AddCoins(int value)
    {
        Coins += value;
    }

    //Object
    [SerializeField] private TMP_Text _coinsText;

    [HideInInspector]
    public int coins = 0;

    public void UpdateText()
    {
        _coinsText.text = $"{coins}";
    }

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }
}
