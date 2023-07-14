using UnityEngine;

public class Fuel : MonoBehaviour, ICollectable
{
    [SerializeField] private int _restoreValue;

    public void OnCollect()
    {
        FuelManager.AddFuel(_restoreValue);
        Destroy(gameObject);
    }
}
