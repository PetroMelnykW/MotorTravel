using Events;
using UnityEngine;

public class WheeledVehicle : Vehicle
{
    [SerializeField] private Rigidbody2D _wheelBack;
    [SerializeField] private Rigidbody2D _wheelFront;
    
    protected override void Movement()
    {
        _wheelBack.AddTorque(-_inputDirection * _speed * Time.fixedDeltaTime);
        _wheelFront.AddTorque(-_inputDirection * _speed * Time.fixedDeltaTime);
        _vehicle.AddTorque(_inputDirection * _rotationSpeed * Time.fixedDeltaTime);
    }
}
