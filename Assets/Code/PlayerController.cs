using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveAcceleration = 20f; // a
    public float rotateSpeed = 120f;
    public float jumpForce = 12f;
    public float hp = 100f;
    public float food = 50f;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotate();
        Jump();
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

        Vector3 direction = transform.forward * v;

        // ? ใช้ F = m * a
        Vector3 force = direction * moveAcceleration * rb.mass;

        rb.AddForce(force);
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