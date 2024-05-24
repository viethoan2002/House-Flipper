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
    [SerializeField] private LayerMask _layerTarget;

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
        if (Physics.Raycast(_playerCtrl._camera.position, _playerCtrl._camera.forward, out var hitBox, raycastDistance, _layerTarget))
        {
            _playerCtrl._playerTools.AddObjectInteract(hitBox.transform.gameObject);
            _playerCtrl._playerTools.AddPointRay(hitBox.point,hitBox.transform.gameObject);
            _playerCtrl._playerTools.AddTriangleIndex(hitBox.triangleIndex,hitBox.transform.gameObject);
        }
        else
            _playerCtrl._playerTools.ClearObjectInteract();
    }

    public void SetLayerTarget(LayerMask _layerMask)
    {
        _layerTarget = _layerMask;
    }

    private void Reset()
    {
        LoadComponent();
    }
}
