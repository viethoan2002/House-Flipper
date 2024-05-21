using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Slot : MonoBehaviour
{
    [SerializeField] private WallController _curWall;

    public void AddWall(WallController _wall)
    {
        _wall.transform.parent.rotation = transform.rotation;
        _wall.transform.position = transform.position;
    }
}
