using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTool : MonoBehaviour
{
    [SerializeField] private Animator _anm;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _anm = GetComponent<Animator>();
    }

    public virtual void UseTool()
    {

    }

    private void Reset()
    {
        LoadComponent();
    }
}
