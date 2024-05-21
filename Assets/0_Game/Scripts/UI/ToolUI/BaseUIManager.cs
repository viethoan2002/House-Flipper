using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _content;

    public virtual void HideUI()
    {
        _content.SetActive(false);
    }

    public virtual void ShowUI() 
    { 
        _content.SetActive(true);
    }
}
