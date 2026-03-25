using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodValue = 20f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController ps = other.GetComponent<PlayerController>();
            if (ps != null)
            {
                ps.AddFood(foodValue);
            }

            Destroy(gameObject);
        }
    }
}