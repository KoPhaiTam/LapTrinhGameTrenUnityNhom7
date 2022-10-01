using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour // tạo waypoint đi và đến của object
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 5f;
    
    private int currentWaypointIndex = 0;
    
    
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < -.1f) //nếu chạm vào waypoint thì di chuyển đến cái tiếp theo
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length) // nếu đã chạy tới waypoint cuối cùng thì chạy lại 
            {
                currentWaypointIndex = 0;
            }
        }
        // di chuyển tile mỗi FPS
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); 
    }
}
