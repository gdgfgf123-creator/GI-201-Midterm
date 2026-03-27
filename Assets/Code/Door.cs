using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAutoKey : MonoBehaviour
{
    public string sceneName; // Scene ปลายทาง

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerKey pk = other.GetComponent<PlayerKey>();

            if (pk != null && pk.hasKey)
            {
                // มี Key → เข้าได้เลย
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                // ไม่มี Key → เข้าไม่ได้
                Debug.Log("🔒 ประตูล็อค! ต้องมีกุญแจก่อน");
            }
        }
    }
}
