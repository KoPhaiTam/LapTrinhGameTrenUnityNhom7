using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Move : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    
    private float distance;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); //Gán distance bằng khoảng cách từ enemy đến player
        Vector2 direction = player.transform.position - transform.position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 10) //Tạo điều kiện để Enemy di chuyển khi có Player di chuyển vào phạm vị hoạt động
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); //Enemy di chuyển về hướng player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); //Enemy sẽ xuay về hướng có player
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
        
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }
}
