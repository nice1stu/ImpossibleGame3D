using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerInst : MonoBehaviour
{
    public GameObject ground;
    private int heightAdjustment;
    private int frameCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;

        if (frameCounter==300)
        {
            int random = Random.Range(-2, 2);
            Debug.Log(random);
            random = Mathf.Clamp(random, -1, 1);
            heightAdjustment = random;
            transform.position += new Vector3(0, heightAdjustment, 0);
            frameCounter = 0;
        }
        Vector3 currentPosition = transform.position;
        Instantiate(ground, currentPosition, Quaternion.identity);
    }
}
