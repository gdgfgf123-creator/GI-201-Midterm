using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winUI.SetActive(true);

            Time.timeScale = 0f; // ËÂØ´à¡Á
        }
    }
}