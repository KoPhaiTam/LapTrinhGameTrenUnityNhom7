using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Di_Chuyen : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX = 0f; //Nhap tu ban phim
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    public PhotonView view; // tạo biến photon view bên object SpawnPlayers

    [SerializeField] private float moveSpeed = 7f; // Tốc độ di chuyển của nhân vật
    [SerializeField] private float jumpForce = 14f; // Lực nhảy của nhân vật

    [SerializeField] private LayerMask jumableGround; // Tạo những nơi chỉ nhảy được

    [SerializeField] int playerHealth = 3;
    [SerializeField] GameObject[] heart;
    public GameObject PlayerCamera;
    private enum MovementState {DungYen, Di, Nhay, Roi} //enum dùng để liệt kê các biến ở trong


    private void Start()
    {
        Debug.Log("Start");
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = heart.Length;
        view = GetComponent<PhotonView>(); // gán view cho component

    }

    // Update is called once per frame
    private void Update()
    {
        if(view.IsMine)
        {
            PlayerCamera.SetActive(true); // nếu là nhân vật của mình mới bật camera
        }
        if(view.IsMine) // chỉ chạy code di chuyển khi nhân vật là của người chơi
        {
            inputX = Input.GetAxisRaw("Horizontal");// Horizontal nằm ở Input manager bao gồm 2 nút di chuyển trái, phái

            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y); //nếu dirX nhập vào >0 thì đi sang phải 7f và ngược lại
            //không nhập giá trị y là 0 vì nếu y ở frame trước là giá trị khác thì khi di chuyển sang trái hoặc phải thì sẽ y sẽ trở lại là 0


            if (Input.GetButtonDown("Jump") && CheckGround())// Sử dụng GetKeyDown sẽ phải gọi đúng nút space Input.GetKeyDown("space")
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // giống như ví dụ di chuyển trái phải ở trên
            }
        }
        
        
        UpdateAnimation();
    }
    private void UpdateAnimation()// Hàm dùng để chuyển đổi animation
    {
        MovementState state;

        if (inputX > 0f) // nếu nhập lớn 0 
        {
            state = MovementState.Di; //thực hiện animation đi
            sprite.flipX = false; // lớn hơn 0 là di chuyển sang phải nên không xoay ngược nhân vật
        }

        else if (inputX < 0f)
        {
            state = MovementState.Di;
            sprite.flipX = true; // bé hơn 0 là di chuyển sang trái nên  xoay ngược nhân vật
        }

        else
        {
            state = MovementState.DungYen; // Animation sẽ đứng yên
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Nhay;// vector y lớn hơn 0 thì sẽ thực hiện animation nhảy
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.Roi;
        }

        

        anim.SetInteger("state", (int)state); // vì đang dùng enum nen giá trị trả về phải là số nguyên
    }

    private bool CheckGround() //hàm này dùng để kiểm tra những nơi mà player có thể nhảy được
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);// BoxCast sẽ tạo ra 1 cái box cùng chỗ với cái collider
        // tạo 1 cái layer trong unity để chỉ check khi ở mặt đất chứ ko va chạm với item
        // cái này dùng để check bên cái LayerMask bên unity khi ta cần check nhảy được nơi player vừa đáp xuống k
        // ví dụ bên cái platform di chuyển qua lại thì ta sẽ vẫn nhảy trên đấy được
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth--; //Maus player sẽ tự trừ
        if(playerHealth < 0) //Điều kiện chết
        {
            anim.SetBool("Dead", false); 
        }
        else
        {
            moveSpeed = 0f;
            anim.SetBool("Dead", false);
        }
        Destroy(heart[playerHealth].gameObject);
    }
}
