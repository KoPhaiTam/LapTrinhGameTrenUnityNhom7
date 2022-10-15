using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    public RoomListing roomItemPrefab;
    List<RoomListing> roomItemsList = new List<RoomListing>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    public float nextUpdateTime;
    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;
    public GameObject playeButton; //the first person join the room will be the Master Client

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if(roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = 3}); // tạo phòng với tối đa 3 người
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false); //kích hoạt Panel phòng
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name; //hiển thị tên phòng đã đặt
        UpdatePlayerList(); //cập nhật danh sách người chơi trong phòng
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime) //cập nhật phòng trên thời gian thực
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;

        }
        
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomListing item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach(RoomInfo room in list) // cập nhật phòng trên danh sách 
        {
            RoomListing newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
        
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName); //tạo phòng
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null) // xóa phòng nếu phòng không có ai
        {
            return;
        }

        foreach(KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players) //đếm số lượng người chơi
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent); //tạo prefab chứa đại diện nhân vật
            newPlayerItem.SetPlayerInfo(player.Value); //chứa thông tin nhân vật
            playerItemsList.Add(newPlayerItem); //thêm nhân vật
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient) //&& PhotonNetwork.CurrentRoom.PlayerCount >= 2 
        {
            playeButton.SetActive(true);
        }
        else
        {
            playeButton.SetActive(false);
        }
       
    }

    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("Map 1"); //Load map for both player
    }
}
