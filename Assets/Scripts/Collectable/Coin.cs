using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int _collectedValue;

    public void OnCollect()
    {
        CoinsManager.AddCoins(_collectedValue);
        Destroy(gameObject);
    }
}
