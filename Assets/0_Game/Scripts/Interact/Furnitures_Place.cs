using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Furnitures_Place : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _col;
    [SerializeField] private float _duration = 0.25f;
    [SerializeField]
    private LayerMask _layerReplace;

    [SerializeField] private Vector3 _originPosition;
    [SerializeField] private int _count = 0;
    private Quaternion _originRotate;

    [SerializeField] private bool _canPlace;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _materialGreen;
    [SerializeField] private Material _materialRed;
    [SerializeField] private List<Material> _materialOrigin=new List<Material>();

    [SerializeField] private Place_Type _placeType;
    [SerializeField] private bool _isPlay;
    [SerializeField] private bool _isOldFur;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
        if (_meshRenderer == null)
            return;

        for(int i=0;i<_meshRenderer.materials.Length;i++)
        {
            _materialOrigin.Add(_meshRenderer.materials[i]);
        }
    }

    public LayerMask GetLayerReplace()
    {
        return _layerReplace;
    }

    public void Replace(Vector3 _pos,GameObject _obj)
    {
        _isPlay = true;

        if (_placeType == Place_Type.onWall)
        {
            float _angle = Vector3.Angle(_obj.transform.forward, Vector3.forward);
            if (_obj.transform.position.x > transform.position.x)
            {
                _angle = -_angle;
            }


            transform.DORotate(new Vector3(0, _angle, 0), 0.25f);
        }

        transform.DOMove(_pos, 0.25f);
    }

    public void EnableCollision(bool _enable)
    {
        _col.isTrigger = _enable;
    }

    public void SetOrigin()
    {
        _originPosition=transform.position;
        _originRotate=transform.rotation;

    }

    public void RevertPlace()
    {
        transform.DOKill();
        transform.position=_originPosition;
        transform.rotation=_originRotate;

        SetMaterialOrigin();
    }

    private bool _isRotate = false;

    public void Rotate(float _angle)
    {
        if (!_isRotate)
        {
            _isRotate = true;

            transform.DORotate(new Vector3(0, _angle, 0), 0.25f, RotateMode.WorldAxisAdd).OnComplete(() =>
            {
                _isRotate = false;
            });
        }
        
    }

    public bool CanPlace()
    {
        return _canPlace;
    }

    public void SetMaterialGreen()
    {
        _canPlace = true;
        Material[] _newMar = _meshRenderer.materials;
        for (int i = 0; i < _newMar.Length; i++)
        {
            _newMar[i] = _materialGreen;
        }

        _meshRenderer.materials = _newMar;
    }

    public void SetMaterialOrigin()
    {
        Material[] _newMar = _meshRenderer.materials;
        for (int i = 0; i < _newMar.Length; i++)
        {
            _newMar[i] = _materialOrigin[i];
        }

        _meshRenderer.materials = _newMar;
        _isPlay = false;
    }

    public void SetMaterialRed()
    {
        _canPlace = false;
        Material[] _newMar = _meshRenderer.materials;

        for (int i = 0; i < _newMar.Length; i++)
        {
            _newMar[i] = _materialRed;
        }

        _meshRenderer.materials = _newMar;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!_isPlay)
    //        return;

    //    _count++;
    //    _canPlace = false;
    //    SetMaterialRed();
    //}

    private void OnTriggerStay(Collider other)
    {
        if(!_isPlay) return;

        SetMaterialRed();
    }

    private void OnTriggerExit(Collider other)
    {
        //if (!_isPlay)
        //    return;

        //_count--;
        //if(_count == 0)
        //{
        if(!_isPlay) return;

        SetMaterialGreen();
        //}
    }

    public bool IsOldFur()
    {
        return _isOldFur;
    }

    public void SetIsOldFur(bool _en)
    {
        _isOldFur = _en;
    }

    private void Reset()
    {
        LoadComponent();
    }
}
