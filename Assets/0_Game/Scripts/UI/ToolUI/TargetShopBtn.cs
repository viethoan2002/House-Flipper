using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetShopBtn : MonoBehaviour
{
    [SerializeField] private Button _curButton;
    [SerializeField] private string _type;

    private void Awake()
    {
        _curButton = GetComponent<Button>();
        _curButton.onClick.AddListener(TargetShop);
    }

    public void SetContentShop(int _index)
    {
        switch(_index)
        {
            case 4:
                _type = "Tiles";
                break;
            case 3:
                _type = "Paints";
                break;
            case 5:
                _type = "Plaster";
                break;
        }
    }

    public void TargetShop()
    {
        PopupController.instance._shopUI.ShowImmediately(false, null);
        PopupController.instance._shopUI.gameObject.SetActive(true);
        PopupController.instance._shopUI._shopContentManager.SetType(2);

        PopupController.instance._shopUI._MENU.SetActive(false);
        PopupController.instance._shopUI._ShopContent.SetActive(true);
        PopupController.instance._shopUI._sideBarManager.SetType(2);
        PopupController.instance._shopUI._shopContentManager.SetContentByString(_type);
    }
}
