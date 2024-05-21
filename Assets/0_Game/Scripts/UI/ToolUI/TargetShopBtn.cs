using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetShopBtn : MonoBehaviour
{
    [SerializeField] private Button _curButton;

    private void Awake()
    {
        _curButton = GetComponent<Button>();
        _curButton.onClick.AddListener(TargetShop);
    }

    public void TargetShop()
    {
        UIController.Instance._shopManager.gameObject.SetActive(true);

        UIController.Instance._shopManager._MENU.SetActive(false);
        UIController.Instance._shopManager._ShopContent.SetActive(true);
        UIController.Instance._shopManager._sideBarManager.SetType(2);
        UIController.Instance._shopManager._shopContentManager.SetContentByString("Plaster");
    }
}
