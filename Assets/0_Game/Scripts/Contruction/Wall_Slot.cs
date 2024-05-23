using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Slot : MonoBehaviour
{
    [SerializeField] private WallController _curWall;
    [SerializeField] private bool isFloor;

    public void AddWall(WallController _wall)
    {
        _wall.transform.parent.rotation = transform.rotation;
        _wall.transform.position = transform.position;
    }

    public void SetIsFloor(bool isFloor)
    {
        this.isFloor = isFloor;
    }

    public bool GetIsFloor()
    {
        return this.isFloor;
    }
}
