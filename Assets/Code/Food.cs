using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodValue = 20f;
    public int scoreValue = 10; // ? เพิ่มคะแนน

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController ps = other.GetComponent<PlayerController>();
            if (ps != null)
            {
                ps.AddFood(foodValue);
                ps.AddScore(scoreValue); // ? เพิ่มตรงนี้
            }

            Destroy(gameObject);
        }
    }
}