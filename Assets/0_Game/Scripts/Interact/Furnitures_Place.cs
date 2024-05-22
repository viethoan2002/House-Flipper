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

    private Vector3 _originPosition;
    private Quaternion _originRotate;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    public LayerMask GetLayerReplace()
    {
        return _layerReplace;
    }

    public void Replace(Vector3 _pos)
    {
        //Vector3 _direction = _pos - transform.position;
        //_direction = new Vector3(_direction.x, transform.position.y, _direction.z);
        //_rigidbody.velocity = _direction * (_direction.magnitude / _duration * Time.deltaTime);
        //transform.DOMove(_pos, 0.25f);
        transform.position = _pos;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "")
        {

        }
    }

    private void Reset()
    {
        LoadComponent();
    }
}
