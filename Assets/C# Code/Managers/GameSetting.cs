using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Manager/GameSetting")]
public class GameSetting : ScriptableObject
{
    [SerializeField] private string nickName = "Tam";
    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return nickName + value.ToString();
        }

    }
}
