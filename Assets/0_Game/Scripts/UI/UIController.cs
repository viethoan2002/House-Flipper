using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Space(30)]
    [Header("UI Component")]
    public HandleUIManager _handleUIManager;

    private void Awake()
    {
        if(UIController.Instance == null)
        {
            UIController.Instance = this;
        }
    }
}
