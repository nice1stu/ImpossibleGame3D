using UnityEngine;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float setCountdownTimer = 15f;

    private float _countdownTime;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        Debug.Assert(_camera != null, "Main Camera not found in the scene!");
        if (_camera == null)
        {
            enabled = false;
        }
    }

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

    // private void RotateCamera()
    // {
    //     if (_camera)
    //     {
    //         Quaternion currentRotation = _camera.transform.rotation;
    //         Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + 180);
    //         _camera.transform.rotation = newRotation;
    //     }
    // }
    
    private void RotateCamera()
    {
        Quaternion currentRotation = _camera.transform.rotation;
        int randomDirection = Random.Range(0, 2);
        float rotationAmount = (randomDirection == 0) ? 90f : -90f;
        Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + rotationAmount);
        _camera.transform.rotation = newRotation;
    }
}

