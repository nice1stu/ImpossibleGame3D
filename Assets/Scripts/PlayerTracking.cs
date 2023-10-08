using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public Transform playerTransform;
    
    private bool _isPlayerTransformNotNull;

    private void Start()
    {
        _isPlayerTransformNotNull = playerTransform != null;
    }

    void Update()
    {
        if (_isPlayerTransformNotNull)
        {
            var position = playerTransform.position;
            Vector3 newPosition = new Vector3(position.x, 0f, position.z+45);
            transform.position = newPosition;
        }
    }
}

