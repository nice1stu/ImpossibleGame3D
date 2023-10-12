using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private void OnEnable()
        {
            ScoreCounter.scoreUpdatedEvent += onScoreUpdated;
            onScoreUpdated(ScoreCounter.Score);
        }

        private void onScoreUpdated(int obj)
        {
            scoreText.text = obj.ToString();
        }

        private void OnDisable()
        {
            ScoreCounter.scoreUpdatedEvent -= onScoreUpdated;
        }
    }
}