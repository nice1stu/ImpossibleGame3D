using UnityEngine;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    
    private float _countdownTime = 60;
    //Allow for shorter countdown times for more frequent camera change and faster / more hazards

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
            _countdownTime = 60;
        }
    }

    private void RotateCamera()
    {
        //Add random change camera angle of 90, 180, -90 in later levels
        Quaternion currentRotation = Camera.main.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + 180);
        Camera.main.transform.rotation = newRotation;
    }
}

