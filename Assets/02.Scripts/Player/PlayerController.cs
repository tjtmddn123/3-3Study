using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;       // �÷��̾��� �̵� �ӵ�
    public float jumpForce = 10.0f;  // ���� ��
    private bool isGrounded = true;  // �÷��̾ ���� �ִ��� Ȯ���ϴ� �÷���
    private Rigidbody2D rigidbody2D; // Rigidbody2D ������Ʈ�� ���� ����

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    void Update()
    {
        // �÷��̾ ���������� �ڵ� �̵�
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // �����̽� �ٰ� ���Ȱ�, �÷��̾ ���� ���� �� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("����");
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // ���� �Ŀ��� ���� ���� ���� ������ ����
        }
    }

    // �ٸ� �ݶ��̴��� �浹���� �� ȣ��Ǵ� �޼ҵ�
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ��Ҵ��� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("�ٴ�");
            isGrounded = true; // ���� ������ isGrounded�� true�� ����
        }
    }
}
