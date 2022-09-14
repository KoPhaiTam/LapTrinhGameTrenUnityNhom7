using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Di_Chuyen : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX = 0f; //Nhap tu ban phim
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");// Horizontal nằm ở Input manager bao gồm 2 nút di chuyển trái, phái

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y); //nếu dirX nhập vào >0 thì đi sang phải 7f và ngược lại
        //không nhập giá trị y là 0 vì nếu y ở frame trước là giá trị khác thì khi di chuyển sang trái hoặc phải thì sẽ y sẽ trở lại là 0


        if (Input.GetButtonDown("Jump"))// Sử dụng GetKeyDown sẽ phải gọi đúng nút space Input.GetKeyDown("space")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // giống như ví dụ di chuyển trái phải ở trên
        }


    }
}
