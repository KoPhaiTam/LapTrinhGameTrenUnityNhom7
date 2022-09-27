using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    //tạo prefab của object player để khi vào game thì sẽ tạo một nhân vật
    public GameObject playerPrefab; // kéo prefab player vào
    public GameObject SceneCamera; //tạo camera khi cho nhân vật vào

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public void Start()
    {
        SceneCamera.SetActive(false);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // tạo vị trí ngẫu nhiên
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity); // khởi tạo người chơi (tên prefab, vị trí ngẫu nhiên, rotation = không)
    }
}
