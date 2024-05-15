using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTool : MonoBehaviour
{
    [SerializeField] public Animator _animator;

    [SerializeField] private GameObject _model;
    private Vector3 _originModelPos;

    [Space(10)]
    [Header("Layer Interact")]
    [SerializeField] private LayerMask targetLayer;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _animator = GetComponent<Animator>();

        _originModelPos = _model.transform.localPosition;
    }

    private void OnEnable()
    {
        FixedTouchField.FixedOnClick += UseTool;
        HandleLoading._completeLoading += CompeleteUse;
    }

    private void OnDisable()
    {
        FixedTouchField.FixedOnClick -= UseTool;
        HandleLoading._completeLoading -= CompeleteUse;

        transform.DOKill();
    }

    public void SetUpPosition()
    {
        gameObject.transform.localPosition = new Vector3(0f, -0.5f, 0f);
    }


    public virtual void UseTool()
    {

    }

    public virtual void CompeleteUse()
    {

    }

    public void HideObject()
    {
        gameObject.SetActive(false);
        gameObject.transform.localPosition = new Vector3(0, -0.5f, 0);
        _model.transform.localPosition = _originModelPos;
    }

    public void ShowObject()
    {
        gameObject.SetActive(true);
        gameObject.transform.DOLocalMove(Vector3.zero, 0.5f);
    }

    public LayerMask GetLayerTarget()
    {
        return targetLayer;
    }

    public virtual void AddInteractObject(GameObject _interactObj)
    {

    }

    public virtual void ClearObjectInteract()
    {

    }

    private void Reset()
    {
        LoadComponent();
    }
}