using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //sử dụng thư viện chuyển scene



public class ConnectToServer : MonoBehaviourPunCallbacks //kế thừa đúng cái này để gọi mấy func dưới
{
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //kết nối với máy chủ 
    }
    
    public override void OnConnectedToMaster() //kiểm tra có đang kết nối với máy chủ không
    {
        PhotonNetwork.JoinLobby(); //function
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby"); //Chuyển scene khi kết nối được
    }
}
