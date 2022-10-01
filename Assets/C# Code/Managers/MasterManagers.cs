using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManagers : ScriptableObjectSingelton<MasterManagers>
{
    [SerializeField] private GameSetting gameSetting;
    public static GameSetting GameSetting 
    {
        get
        {
            return Instance.gameSetting;
        }
    }
}
