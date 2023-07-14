using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    [SerializeField] protected float _speed = 150;
    [SerializeField] protected float _rotationSpeed = 300;
    [SerializeField] protected Rigidbody2D _vehicle;

    [SerializeField] private Pedal _leftPedal;
    [SerializeField] private Pedal _rightPedal;

    protected int _inputDirection = 0;

    private bool _leftPedalPressed = false;
    private bool _rightPedalPressed = false;

    protected void Update()
    {
        CheckInput();
        Movement();
    }

    protected void FixedUpdate()
    {
        Movement();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<ICollectable>()?.OnCollect();
    }

    protected void CheckInput()
    {
        _inputDirection = (_leftPedalPressed ? -1 : 0) + (_rightPedalPressed ? 1 : 0);
    }

    protected abstract void Movement();

    private void Awake()
    {
        _leftPedal.Subscribe(OnLeftPedalAction);
        _rightPedal.Subscribe(OnRightPedalAction);
    }

    private void OnLeftPedalAction(bool isPressed)
    {
        _leftPedalPressed = isPressed;
    }

    private void OnRightPedalAction(bool isPressed)
    {
        _rightPedalPressed = isPressed;
    }
}
