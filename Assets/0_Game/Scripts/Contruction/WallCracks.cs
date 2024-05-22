using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallCracks : MonoBehaviour
{
    [SerializeField] private GameObject _fillObject;
    [SerializeField] private float _fillAmount;
    [SerializeField] private bool _canFill;

    bool _canFix = true;

    public float GetFillAmount()
    {
        return _fillAmount;
    }

    public bool CanFix()
    {
        return _canFix;
    }

    public void SetCanFill(bool _can)
    {
        _canFill = _can;
    }

    public void FillWallCrack(float _timeFill)
    {
        StartCoroutine(Fill(_fillAmount, _timeFill));
    }

    IEnumerator Fill(float _curValue, float _timeFill)
    {
        float duration = _timeFill * (1 - _curValue);

        _fillObject.transform.localScale = new Vector3(1, _curValue,1);

        float elapsedTime = 0f;

        while (elapsedTime < duration && _canFill)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            _fillObject.transform.localScale = new Vector3(1, Mathf.Lerp(_curValue, 1f, t), 1) ;
            _fillAmount = Mathf.Lerp(_curValue, 1f, t);

            yield return null;
        }

        _canFix = false;
    }
}
