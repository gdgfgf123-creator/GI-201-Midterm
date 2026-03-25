using UnityEngine;

public class Shelter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            // ไป Scene Credit ได้ตรงนี้
        }
    }
}