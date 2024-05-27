using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHome : BasePopup
{
    [SerializeField] private Button _btnPlay;
    [SerializeField] private GameObject _content,_loading;

    [SerializeField] private Image _fillImage;

    private void Awake()
    {
        _btnPlay.onClick.AddListener(Loading);
    }

    private void Loading()
    {
        _content.SetActive(false);
        _loading.SetActive(true);

        StartCoroutine(Fill(0,3));
    }

    IEnumerator Fill(float _curValue, float _timeFill)
    {
        float duration = _timeFill * (1 - _curValue);

        _fillImage.fillAmount = _curValue;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            _fillImage.fillAmount = Mathf.Lerp(_curValue, 1f, t);

            yield return null;
        }

        HideImmediately(false, null);
    }

}
