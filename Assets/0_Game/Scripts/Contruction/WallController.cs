using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private Wall_Bonus _right, _left;
    [SerializeField] private Outline outline;

    [Space(30)]
    [SerializeField] private bool _canDestroy;

    public void Build(Vector3 _pos,Quaternion _ro)
    {
        transform.position = _pos;
        transform.rotation = _ro;
    }

    public void ActiveOutline(bool _active)
    {
        outline.enabled = _active;
    }

    public bool CanDestroy()
    {
        return _canDestroy;
    }
}
