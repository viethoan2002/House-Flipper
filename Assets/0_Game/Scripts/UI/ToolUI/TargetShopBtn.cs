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
        UIController.Instance._shopManager.gameObject.SetActive(true);
        UIController.Instance._shopManager._shopContentManager.SetType(2);

        UIController.Instance._shopManager._MENU.SetActive(false);
        UIController.Instance._shopManager._ShopContent.SetActive(true);
        UIController.Instance._shopManager._sideBarManager.SetType(2);
        UIController.Instance._shopManager._shopContentManager.SetContentByString(_type);
    }
}
