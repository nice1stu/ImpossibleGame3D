using UnityEngine;
using System;


public class Stopwatch : MonoBehaviour
{
    private bool _isRunning;
    private float _startTime;
    private float _elapsedTime;
    void Start()
    {
        _startTime = Time.time;
        StartStopwatch();
    }

    void Update()
    {
        if (_isRunning)
        {
            _elapsedTime = Time.time - _startTime;
            Debug.Log(_elapsedTime);
        }

        TimeSpan time = TimeSpan.FromSeconds(_startTime);
        //CurrentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartStopwatch()
    {
        _isRunning = !_isRunning;
    }

    public void ResetStopwatch()
    {
        _startTime = Time.time;
        _isRunning = false;
    }
}
