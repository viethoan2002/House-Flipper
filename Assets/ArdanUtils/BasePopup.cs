using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

public class BasePopup : MonoBehaviour
{
    public RectTransform main;
    public CanvasGroup canvasGroup;
    public ButtonEffectLogic btnClose;
    public bool showing;
    
    protected float timeScale = .25f;
    protected Vector3 scaleWhenShow = Vector3.zero;

    protected virtual void Start()
    {
        if (btnClose)
        {
            btnClose.onClick.AddListener(() =>
            {
                HideImmediately(false);
            });
        }
    }

    public virtual void ShowImmediately(bool showImmediately)
    {
        showing = true;
        DOTween.Kill(main);
        gameObject.SetActive(true);
        if (canvasGroup)
        {
            
            canvasGroup.interactable = true;
            if (showImmediately)
            {
                canvasGroup.alpha = 1;
                main.localScale = Vector3.one;
            }
            else
            {
                canvasGroup.DOFade(1, timeScale).From(0).OnComplete(() => { canvasGroup.interactable = true; });
                //main.DOScale(Vector3.one, timeScale).From(scaleWhenShow);
            }
        }
        else
        {
            // if (showImmediately)
            // {
            //     main.localScale = Vector3.one;
            // }
            // else
            // {
            //     main.DOScale(Vector3.one, timeScale).From(scaleWhenShow);
            // }
        }
    }

    public virtual void HideImmediately(bool hideImmediately, Action actionComplete = null)
    {
        if (hideImmediately)
        {
            gameObject.SetActive(false);
            actionComplete?.Invoke();
            showing = false;
        }
        else if (canvasGroup)
        {
            canvasGroup.DOFade(0, timeScale).OnComplete(() =>
            {
                canvasGroup.interactable = false;
                gameObject.SetActive(false);
                actionComplete?.Invoke();
                showing = false;
            });
            //main.DOScale(Vector3.zero, timeScale);
        }
        else
        {
            // main.DOScale(Vector3.zero, timeScale).OnComplete(() =>
            // {
                gameObject.SetActive(false);
                actionComplete?.Invoke();
                showing = false;
            //});
        }
    }

    public IEnumerator Delay(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}