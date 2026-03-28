using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float rotateSpeed = 120f;
    public float jumpForce = 12f;
    public float hp = 100f;
    public float food = 50f;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ?? ล็อคไม่ให้ล้ม/หมุนมั่ว
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // ?? ลดการไถล
        rb.drag = 3f;
        rb.angularDrag = 5f;
    }

    void Update()
    {
        Rotate();
        Jump();

        // ระบบอาหาร
        food -= Time.deltaTime * 2f;
        if (food <= 0)
        {
            hp -= Time.deltaTime * 5f;
        }

        if (hp <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float v = 0;

        if (Keyboard.current != null)
        {
            v = (Keyboard.current.wKey.isPressed ? 1f : 0)
              - (Keyboard.current.sKey.isPressed ? 1f : 0);
        }

        Vector3 move = transform.forward * v * moveSpeed;

        // ?? ใช้ velocity แทน AddForce (นิ่งกว่า ไม่หมุน)
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    void Rotate()
    {
        float h = 0;

        if (Keyboard.current != null)
        {
            h = (Keyboard.current.dKey.isPressed ? 1f : 0)
              - (Keyboard.current.aKey.isPressed ? 1f : 0);
        }

        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        bool jumpPressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;

        if (jumpPressed && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // รีเซ็ตแรงตก
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    public void AddFood(float amount)
    {
        food += amount;
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }
}