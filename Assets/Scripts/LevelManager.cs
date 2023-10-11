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
