using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemLights", menuName = "Data/Items/Lights")]
public class ItemLights : BaseItem
{
    public Lights _type;

    public override string GetTypeString()
    {
        return _type.ToString();
    }
}
