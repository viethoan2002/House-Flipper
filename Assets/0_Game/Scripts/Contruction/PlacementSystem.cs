using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float raycastDistance;
    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private LayerMask _placementLayerMask;

    private void Update()
    {
        CheckGroundPosition();
    }

    private void CheckGroundPosition()
    {
#if UNITY_EDITOR
        Debug.DrawLine(_camera.position, _camera.position - (-_camera.forward) * raycastDistance, Color.red);
#endif
        if (Physics.Raycast(_camera.position, _camera.forward, out var hitBox, raycastDistance, _placementLayerMask))
        {
            lastPosition = hitBox.point;
            if(hitBox.transform.GetComponent<GroundCtrl>() != null)
                hitBox.transform.GetComponent<GroundCtrl>().UpdateCellPos(hitBox.point);
        }
    }
}
