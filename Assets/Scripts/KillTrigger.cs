using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            if (other.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rb.isKinematic = true;
                StartCoroutine(DelayPause());
            }

            if (other.gameObject.TryGetComponent(out PlayerMovement movement))
            {
                movement.enabled = false;
            }
        }
    }

    private IEnumerator DelayPause()
    {
        var elapsed = 0f;
        while (elapsed < duration)
        {
            Time.timeScale = Mathf.Lerp(1f, 0f, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        Time.timeScale = 0f;
    }

    public void Explode()
    {
        /*GroundTile tiles = GameObject.FindObjectsByType(FindObjectsInactive.Exclude);
        foreach (var VARIA in tiles)
        {
            
        }*/
    }
}
