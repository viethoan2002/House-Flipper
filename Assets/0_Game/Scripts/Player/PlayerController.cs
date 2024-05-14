using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Transfrom")]
    public Transform _player;
    public Transform _camera;
    public Transform _toolTrans;

    [Space(30)]
    [Header("Player Component")]
    public PlayerMovement _playerMovement;
    public PlayerInteract _playerInteract;
    public PlayerTools _playerTools;

    private void Awake()
    {
        LoadComponent();
    }

    public void LoadComponent()
    {
        _player=GetComponent<Transform>();

        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerTools = GetComponent<PlayerTools>();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
