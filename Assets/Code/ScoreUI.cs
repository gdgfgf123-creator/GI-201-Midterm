using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + player.score;
    }
}