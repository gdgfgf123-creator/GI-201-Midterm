using UnityEngine;

public class WarningBlink : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * 0.2f;
        transform.localScale = new Vector3(scale, 0.01f, scale);
    }
}