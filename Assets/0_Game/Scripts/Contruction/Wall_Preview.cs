using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Preview : MonoBehaviour
{
    [SerializeField] private bool _canBuild;

    [SerializeField] private Material _marCanBuid, _marCanNotBuild;
    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private int _amountCollision = 0;

    public bool CanBuild()
    {
        return _canBuild;
    }

    public void ActivePreview(bool _active)
    {
        _renderer.enabled = _active;
    }

    public void ResetPreview()
    {
        _amountCollision = 0;
        gameObject.SetActive(false);
        _renderer.material = _marCanBuid;
    }

    public void Preview(Transform _trans)
    {
        ActivePreview(true);
        transform.DOMove(_trans.transform.position, 0.25f);
        //transform.DORotateQuaternion(_trans.transform.rotation, 0.25f);
        //transform.position = _trans.transform.position;
        transform.rotation = _trans.transform.rotation;
    }

    private void UpDatePreviewByMaterial(bool _en)
    {
        if (_en)
        {
            _renderer.material = _marCanBuid;
        }
        else
        {
            _renderer.material = _marCanNotBuild;
        }

        UIController.Instance._handleUIManager._handleNotification.ActiveNotifiTap(_en);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canBuild = false;
        UpDatePreviewByMaterial(_canBuild);
        _amountCollision++;
    }

    private void OnCollisionExit(Collision collision)
    {
        _amountCollision--;
        if(_amountCollision == 0)
        {
            _canBuild = true;
            UpDatePreviewByMaterial(_canBuild);
        }
    }
}
