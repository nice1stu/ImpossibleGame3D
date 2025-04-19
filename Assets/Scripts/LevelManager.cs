using UnityEngine;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float setCountdownTimer = 15f;

    private float _countdownTime;
    private void Awake()
    {
        Time.timeScale = 1; 
        _countdownTime = setCountdownTimer;
    }

    private void Update()
    {
        _countdownTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(_countdownTime / 60);
        int seconds = Mathf.FloorToInt(_countdownTime % 60);
        countdownText.text = $"{minutes:00}:{seconds:00}";
        
        countdownText.color = _countdownTime <= 10 ? Color.red : Color.white;

        if (_countdownTime <= 0)
        {
            RotateCamera();
            _countdownTime = setCountdownTimer;
        }
    }

    private void RotateCamera()
    {
        if (Camera.main != null)
        {
            Quaternion currentRotation = Camera.main.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + 180);
            Camera.main.transform.rotation = newRotation;
        }
    }
    
    /*
     * private void RotateCamera()
    {
        // random change camera angle of 0, 90, 180, -90 in later levels
        if (Camera.main != null)
            {
                Quaternion currentRotation = Camera.main.transform.rotation;
                int angle = Random.Range(0, 4); // Generate a random number between 0 and 3, inclusive
                angle *= 90; // Multiply the result by 90 to get one of the four possible angles
                Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + angle);
                Camera.main.transform.rotation = newRotation;
            }
    }
     */
}

