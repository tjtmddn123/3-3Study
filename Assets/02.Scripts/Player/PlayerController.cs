using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;       // 플레이어의 이동 속도
    public float jumpForce = 10.0f;  // 점프 힘
    private bool isGrounded = true;  // 플레이어가 땅에 있는지 확인하는 플래그
    private Rigidbody2D rigidbody2D; // Rigidbody2D 컴포넌트에 대한 참조

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        // 플레이어를 오른쪽으로 자동 이동
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // 스페이스 바가 눌렸고, 플레이어가 땅에 있을 때 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("점프");
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // 점프 후에는 땅에 있지 않은 것으로 설정
        }
    }

    // 다른 콜라이더와 충돌했을 때 호출되는 메소드
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 땅에 닿았는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("바닥");
            isGrounded = true; // 땅에 닿으면 isGrounded를 true로 설정
        }
    }
}
