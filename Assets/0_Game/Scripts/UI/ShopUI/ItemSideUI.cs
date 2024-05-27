using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSideUI : MonoBehaviour
{
    [SerializeField] private Button _curButton;
    [SerializeField] private Text _name;

    private void Awake()
    {
        _curButton=GetComponent<Button>();
        _curButton.onClick.AddListener(ActionClick);
    }

    public void ActionClick()
    {
        PopupController.instance._shopUI._shopContentManager.SetContentByString(_name.text);
    }

    public void SetTyprByString(string _type)
    {
        _name.text = _type;
    }
}
