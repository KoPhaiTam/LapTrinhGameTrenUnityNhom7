using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //sử dụng thư viện chuyển scene
using Photon.Realtime;



public class ConnectToServer : MonoBehaviourPunCallbacks //kế thừa đúng cái này để gọi mấy func dưới
{
    public void Start()
    {
        //PhotonNetwork.NickName = MasterManagers.GameSetting.NickName;
        PhotonNetwork.ConnectUsingSettings(); //kết nối với máy chủ 
    }
    
    public override void OnConnectedToMaster() //kiểm tra có đang kết nối với máy chủ không
    {
        PhotonNetwork.JoinLobby(); //function
        //Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnect" + cause.ToString());
    }
    
    public override void OnJoinedLobby()
    {
        Debug.Log("Connect to Lobby...");
        SceneManager.LoadScene("Lobby"); //Chuyển scene khi kết nối được
    }
}
