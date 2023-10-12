using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 4f;
    //Allow for faster moveSpeed in later levels

    public void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed) * Time.deltaTime;
    }
}