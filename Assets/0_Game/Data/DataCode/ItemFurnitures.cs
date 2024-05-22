using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemFurnitures", menuName = "Data/Items/ItemFurnitures")]
public class ItemFurnitures : BaseItem
{
    public Furniture _type;

    public override string GetTypeString()
    {
        return _type.ToString();
    }
}
