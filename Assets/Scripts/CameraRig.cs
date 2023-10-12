using UnityEngine;

public class CameraRig : MonoBehaviour, IPlayerTracking
{
    public Transform playerTransform;
    
    private bool _isPlayerTransformNotNull;

    private void Start()
    {
        _isPlayerTransformNotNull = playerTransform != null;
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (_isPlayerTransformNotNull)
        {
            var position = playerTransform.position;
            Vector3 newPosition = new Vector3(position.x, position.y + 6.5f, (position.z-5));
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(+35, rotation.eulerAngles.y, rotation.eulerAngles.z);
            var transform1 = transform;
            transform1.rotation = rotation;
            transform1.position = newPosition;
        }
    }
}
