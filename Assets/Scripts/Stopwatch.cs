using UnityEngine;
using TMPro;


public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stopwatchText;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);
        stopwatchText.text = $"{minutes:00}:{seconds:00}";
        if (_elapsedTime >= 60)
        {
            RotateCameraEvery60Seconds();
            _elapsedTime -= 60;
        }
    }

    public void RotateCameraEvery60Seconds()
    {
        Quaternion currentRotation = Camera.main.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, 0, currentRotation.eulerAngles.z + 180);
        Camera.main.transform.rotation = newRotation;
    }
}
