using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController instance;
    public PopupProfile _profileUI;
    public PopupPause _pauseUI;
    public PopupShop _shopUI;
    public PopupCoint _cointUI;
    public PopupGamePlay _gameplayUI;

    private void Awake()
    {
        PopupController.instance = this;
    }
}
