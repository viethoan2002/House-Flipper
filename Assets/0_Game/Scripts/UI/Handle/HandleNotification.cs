using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleNotification : MonoBehaviour
{
    [SerializeField] private GameObject _iconTap,_notiObj, _waringObj;
    [SerializeField] private Text _notiTxt, _waringTxt;
    [SerializeField] private Image _notiImg, _waringImg;

    public void SetNoTi(string _txt)
    {
        _notiTxt.text = _txt;
        _notiImg.rectTransform.sizeDelta = new Vector2(_txt.Length * 12 + 70, 40);
        _notiObj.SetActive(true);
        _iconTap.SetActive(true);
    }

    public void SetWaring(string _txt)
    {
        _waringTxt.text = _txt;
        _waringImg.rectTransform.sizeDelta = new Vector2(_txt.Length * 12 + 70, 40);
        _waringObj.SetActive(true);
    }

    public void CloseNoti()
    {
        _notiObj.SetActive(false);
        _iconTap.SetActive(false);
    }

    public void CloseWaring()
    {
        _waringObj.SetActive(false);
    }
}
