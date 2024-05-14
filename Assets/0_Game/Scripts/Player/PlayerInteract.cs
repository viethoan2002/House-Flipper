using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private PlayerController _playerCtrl;

    [SerializeField] private float raycastDistance = 5.0f;

    [Space(30)]
    [Header("CheckRaycast")]
    [SerializeField] private int interact_layer = 0;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _playerCtrl = GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckRaycast();
    }

    private void CheckRaycast()
    {

#if UNITY_EDITOR
        Debug.DrawLine(_playerCtrl._camera.position, _playerCtrl._camera.position - (-_playerCtrl._camera.forward) * raycastDistance, Color.red);
#endif
        if (Physics.Raycast(_playerCtrl._camera.position, _playerCtrl._camera.forward, out var hitBox, raycastDistance, _layerMask)) 
            Debug.Log(hitBox.transform.ToString());
    }

    private void Reset()
    {
        LoadComponent();
    }
}
