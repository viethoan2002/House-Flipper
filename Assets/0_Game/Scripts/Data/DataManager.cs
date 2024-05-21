using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public DataController _BackyardData;
    public DataController _Lights;
    public DataController _WallFinishesData;
    public DataController _DoorData;
    public DataController _FurnitureData;
    public DataController _WindowsData;
    public DataController _DecoData;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
