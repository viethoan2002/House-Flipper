using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : MonoBehaviour
{
    [SerializeField] private Button _btnProfile;
    [SerializeField] private Button _btnPause;
    [SerializeField] private Button _btnShop;
    [SerializeField] public HandleUIManager _handleUI;
    public ToolUIManager _toolUI;
    public ReplaceUIManager _replaceUI;

    private void Awake()
    {
        _btnProfile.onClick.AddListener(ShowProfile);
        _btnPause.onClick.AddListener(ShowPause);
        _btnShop.onClick.AddListener(ShowShop);
    }

    public void ShowProfile()
    {
        PopupController.instance._profileUI.ShowImmediately(false, null);
    }

    public void ShowPause()
    {
        PopupController.instance._pauseUI.ShowImmediately(false, null);
    }

    public void ShowShop()
    {
        PopupController.instance._shopUI.ShowImmediately(false, null);
    }
}
