using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        LoadComponent();
        _button.onClick.AddListener(DoSth);
    }

    private void LoadComponent()
    {
        _button = GetComponent<Button>();
    }

    public virtual void DoSth()
    {

    }
}
