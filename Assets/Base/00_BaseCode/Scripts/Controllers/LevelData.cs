using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public List<BaseHex> lsBaseSetUp;
    public void Init()
    {
        foreach(var item in lsBaseSetUp)
        {
            item.HandleSpawnHex();
        }
    }
        
}
