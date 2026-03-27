using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าเป็นกุญแจไหม (ใช้ Tag)
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("ได้กุญแจแล้ว!");

            Destroy(other.gameObject); // ลบกุญแจออกจากฉาก
        }
    }
}
