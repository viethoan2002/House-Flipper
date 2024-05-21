using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Bonus : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Collider _col;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _renderer = GetComponent<MeshRenderer>();
        _col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall_Bonus")
        {
            _renderer.enabled = true;
            _col.isTrigger = false;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Wall_Bonus")
        {
            _renderer.enabled = false;
            _col.isTrigger = true;
        }
    }

    private void Reset()
    {
        LoadComponent();
    }
}
