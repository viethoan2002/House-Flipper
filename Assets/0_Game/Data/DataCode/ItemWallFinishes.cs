using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemWallFinishes", menuName = "Data/Items/ItemWallFinishes")]
public class ItemWallFinishes : BaseItem
{
    public Sprite _texture;
    public WallFinishes _type;
    public Material _material;

    public override string GetTypeString()
    {
        return _type.ToString();
    }
}
