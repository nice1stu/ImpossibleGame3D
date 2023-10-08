using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 2f;

    public void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed) * Time.deltaTime;
    }
}