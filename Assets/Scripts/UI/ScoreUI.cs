using _GAME_.Scripts.Actions;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreTMP;
    private int score;
    private void OnEnable()
    {
        GameFlow.levelCreated += ResetScore;
        GameFlow.passedObstacle += IncreaseScore;
    }

    private void OnDisable()
    {
        GameFlow.levelCreated -= ResetScore;
        GameFlow.passedObstacle -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        score++;
        scoreTMP.text = score.ToString();
    }

    private void ResetScore()
    {
        score = 0;
        scoreTMP.text = score.ToString();
    }
}
