using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrls : MonoBehaviour
{
    [SerializeField, Min(0.1f)]
    private float _movementSpeed = 1;
    private Vector3 _movementDir;

    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Vector3 _cameraPosShift;
    [SerializeField]
    private Vector3 _cameraRotation;

    private void Update()
    {
        Move();
    }
    private void OnMove(InputValue inputAction)
    {
        Vector2 inputMovement = inputAction.Get<Vector2>();
        _movementDir = new Vector3(inputMovement.x, 0, inputMovement.y);

    }

    private void Move() => transform.Translate(_movementDir * _movementSpeed * Time.deltaTime);

    public void SetCameraData()
    {
        _camera.transform.position = transform.position + _cameraPosShift;
        _camera.transform.rotation = Quaternion.Euler(_cameraRotation.x, _cameraRotation.y, _cameraRotation.z);
    }

}

