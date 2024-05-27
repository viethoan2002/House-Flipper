using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    public bool isShow;
    
    [SerializeField] protected Transform main;
    
    protected float timeShow = .25f;
    protected Vector3 scaleWhenShow = Vector3.zero;

    public virtual void ShowImmediately(bool showImmediately, Action actionComplete = null)
    {
        isShow = true;
        DOTween.Kill(main);
        gameObject.SetActive(true);
        if (showImmediately)
        {
            main.localScale = Vector3.one;
            actionComplete?.Invoke();
        }
        else
        {
            main.DOScale(Vector3.one, timeShow).From(scaleWhenShow).SetUpdate(true).OnComplete(() =>
            {
                actionComplete?.Invoke();
            });
        }
    }

    public virtual void HideImmediately(bool hideImmediately, Action actionComplete = null)
    {
        isShow = false;
        if (hideImmediately)
        {
            gameObject.SetActive(false);
            actionComplete?.Invoke();
        }
        else
        {
            main.DOScale(Vector3.zero, timeShow).SetUpdate(true).OnComplete(() =>
            {
                gameObject.SetActive(false);
                actionComplete?.Invoke();
            });
        }
    }
    
    protected virtual void OnDisable()
    {
        main.DOKill();
    }
}