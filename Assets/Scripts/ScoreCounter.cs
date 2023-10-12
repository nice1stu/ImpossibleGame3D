using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreCounter : MonoBehaviour
    {
        private static int score;
        
        public static int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                scoreUpdatedEvent?.Invoke(Score);
                Debug.Log(Score);
            }
        }

        public static event Action<int> scoreUpdatedEvent; 
        private void Start()
        {
            Score = 0;
        }
    }
}