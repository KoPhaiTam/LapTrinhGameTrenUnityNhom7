using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
   public InputField createInput; // tạo tên phòng (sử dụng Input field object)
   public InputField joinInput; // nhập tên phòng (sử dụng Input field object)

   public void CreateRoom()// gọi func tạo phòng
   {
        
     
        PhotonNetwork.CreateRoom(createInput.text); // lưu ý phải kết nối với máy chủ trước rồi mới tạo hoặc join phòng
   }

   public void JoinRoom() //hàm tham gia phòng
   {
        PhotonNetwork.JoinRoom(joinInput.text);
   }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel("Map 1"); // chạy game khi tạo hoặc join phòng
    }
}
