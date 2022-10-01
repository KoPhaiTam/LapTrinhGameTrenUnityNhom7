using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;


public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        text.text = roomInfo.Name;
    }
    
}
