using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public static BuildingController instance;
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _placementSystem;

    private void Awake()
    {
        BuildingController.instance = this;
    }

    public void ActivePlacementSystem(bool _active)
    {
        _camera.gameObject.SetActive(_active);
        _placementSystem.SetActive(_active);
    }
}
