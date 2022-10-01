using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    // [SerializeField] private Text roomName;

    // public void OnClick_CreateRoom()
    // {
    //     if(!PhotonNetwork.IsConnected)
    //     {
    //         return;
    //     }
    //     RoomOptions options = new RoomOptions();
    //     options.MaxPlayers = 4;
    //     PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    // }

    public override void OnCreatedRoom()
    {
        Debug.Log(" Tao phong thanh cong. ", this);
        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
       Debug.Log(" Tao phong that bai. " + message, this);
    }
}
