using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float fallForce = 30f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // ใช้แรงตกลง (F = m * a)
        rb.AddForce(Vector3.down * fallForce * rb.mass, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            // ใส่ระบบลด HP ได้ตรงนี้
        }

        Destroy(gameObject, 0.5f);
    }
}