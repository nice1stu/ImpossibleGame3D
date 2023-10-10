using UnityEngine;
using System;
using TMPro;


public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stopwatchText;
    private float _elapsedTime;

    void Update()
    {
            _elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            stopwatchText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            Debug.Log(_elapsedTime);
    }
}
