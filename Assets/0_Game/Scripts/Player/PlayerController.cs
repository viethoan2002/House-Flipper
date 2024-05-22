using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Transfrom")]
    public Transform _player;
    public Transform _camera;
    public Transform _toolTrans;

    [Space(30)]
    [Header("Player Component")]
    public PlayerMovement _playerMovement;
    public PlayerInteract _playerInteract;
    public PlayerTools _playerTools;
    public PlayerAnimator _playerAnimator;
    public PlayerStats _playerStats;

    private void Awake()
    {
        if(PlayerController.instance == null)
        {
            PlayerController.instance = this;
        }

        LoadComponent();
    }

    public void LoadComponent()
    {
        _player=GetComponent<Transform>();

        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerTools = GetComponent<PlayerTools>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
