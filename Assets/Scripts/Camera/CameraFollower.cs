using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private const float DEFAULT_Z_CAMERA_POSITION = -10f;

    [SerializeField] private float _followSpeed = 2f;
    [SerializeField] private float _yOffset = 1f;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 newCameraPosition = new Vector3(transform.position.x, transform.position.y + _yOffset, DEFAULT_Z_CAMERA_POSITION);
        _mainCamera.transform.position = Vector3.Slerp(_mainCamera.transform.position, newCameraPosition, _followSpeed * Time.deltaTime);
    }
}
