using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private float _fillAmount;
    [SerializeField] private bool _isCleaning;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _collider = GetComponent<Collider>();
    }

    public void SetFillAmount(float _amout)
    {
        _fillAmount = _amout;
    }

    public float GetFillAmount()
    {
        return _fillAmount;
    }

    public void SetCleaning(bool _en)
    {
        _isCleaning = _en;
    }

    public bool GetCleaning()
    {
        return _isCleaning;
    }

    public void ClearDirt()
    {
        Destroy(gameObject);
    }

    private void Reset()
    {
        LoadComponent();
    }
}
