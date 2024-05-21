using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertBtn : BaseButton
{
    public static event Action _revertReplace;

    public override void DoSth()
    {
        base.DoSth();

        _revertReplace?.Invoke();
    }
}
