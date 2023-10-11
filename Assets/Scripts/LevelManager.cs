using UnityEngine;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private float _countdownTime = 60;

    private void Update()
    {
        _countdownTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(_countdownTime / 60);
        int seconds = Mathf.FloorToInt(_countdownTime % 60);
        countdownText.text = $"{minutes:00}:{seconds:00}";

        // Change the color of the countdown clock numbers to red when time reaches 10 seconds.
        if (_countdownTime <= 10)
        {
            countdownText.color = Color.red;
        }
        else
        {
            countdownText.color = Color.white;
        }

        if (_countdownTime <= 0)
        {
            RotateCamera();
            _countdownTime = 60;
        }
    }

    public void RotateCamera()
    {
        Quaternion currentRotation = Camera.main.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + 180);
        Camera.main.transform.rotation = newRotation;
    }
}

