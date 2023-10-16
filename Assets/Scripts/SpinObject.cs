using UnityEngine;

public class SpinObject : MonoBehaviour
{
    private Vector3 upAxis = Vector3.up;

    void Start()
    {
        upAxis = Vector3.up;
    }

    void Update()
    {
        transform.Rotate(upAxis * (Time.deltaTime * 150));
    }
}

