using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private void OnEnable()
    {
        ScoreCounter.ScoreUpdatedEvent += OnScoreUpdated;
        OnScoreUpdated(ScoreCounter.Score);
    }

    private void OnScoreUpdated(int obj)
    {
        scoreText.text = obj.ToString();
    }

    private void OnDisable()
    {
        ScoreCounter.ScoreUpdatedEvent -= OnScoreUpdated;
    }
}