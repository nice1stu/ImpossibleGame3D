using UnityEngine;

public class HazardsCleared : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            ScoreCounter.Score++;
    }
}
