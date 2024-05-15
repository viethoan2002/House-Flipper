using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController _playerCtrl;

    [Space(30)]
    [Header("Joystick")]
    public FixedJoystick joystick;
    public FixedTouchField touchField;

    [Space(30)]
    [Header("Rotate")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float xRotation = 0;
    [SerializeField] private bool _canRotate = true;

    [Space(30)]
    [Header("Movement")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private bool _canMove = true;
    [SerializeField] private float speed = 25;
    [SerializeField] private float gravity = 9.81f;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _playerCtrl = GetComponent<PlayerController>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        if (!_canRotate)
            return;

        if(!touchField.isPressed)
            return;

        float mouseX = touchField.TouchDist.x * mouseSensitivity * Time.deltaTime;
        float mouseY = touchField.TouchDist.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        _playerCtrl._camera.transform.localRotation=Quaternion.Euler(xRotation, 0, 0);
        _playerCtrl._player.transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        if(!_canMove)
            return;

#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
#endif
        if (joystick.Direction != Vector2.zero)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }

        Vector3 move = transform.right * x + transform.forward * y;

        _controller.Move(move * speed * Time.deltaTime);

        _controller.Move(-_playerCtrl._player.up * gravity * Time.deltaTime);

        _playerCtrl._playerAnimator.UpdateAnmByVelocity(move);
    }

    public void ActiveMovement(bool _active)
    {
        _canMove = _active;
    }

    public void ActiveRotate(bool _active)
    {
        _canRotate = _active;
    }

    private void Reset()
    {
        LoadComponent() ;
    }
}
