using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private static int _score;
        
    public static int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreUpdatedEvent?.Invoke(Score);
        }
    }

    public static event Action<int> ScoreUpdatedEvent; 
    private void Start()
    {
        Score = 0;
    }
}