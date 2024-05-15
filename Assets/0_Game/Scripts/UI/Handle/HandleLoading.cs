using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleLoading : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private Image _backGround;
    [SerializeField] private bool _canFill;

    public static event Action _completeLoading;
    public void SetCanFill(bool _can)
    {
        _canFill=_can;
    }

    public void HandleFill(float _curValue,float _timeFill)
    {
        ActiveImage(true);
        StartCoroutine(Fill(_curValue, _timeFill));
    }

    IEnumerator Fill(float _curValue,float _timeFill)
    {
        float duration = _timeFill * (1 - _curValue);

        _fillImage.fillAmount=_curValue;

        float elapsedTime = 0f;

        while (elapsedTime < duration && _canFill)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            _fillImage.fillAmount = Mathf.Lerp(_curValue, 1f, t);

            yield return null;
        }   

        ActiveImage(false);
        
        if(elapsedTime > duration)
            _completeLoading?.Invoke(); 
    }

    private void ActiveImage(bool _active)
    {
        _fillImage.gameObject.SetActive(_active);
        _backGround.gameObject.SetActive(_active);
    }

    public float GetFillAmount()
    {
        return _fillImage.fillAmount;
    }
}
