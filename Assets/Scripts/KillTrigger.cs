using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTrigger : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
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
                movement.enabled = false;
            
            Erupt();
            SceneManager.LoadScene(2);
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

    private void Erupt()
    {
        var tiles = FindObjectsByType<GroundTile>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach (var groundTile in tiles)
        {
            if (!groundTile.TryGetComponent(out Rigidbody rb))
                rb = groundTile.AddComponent<Rigidbody>();

            float force = 10f;
            rb.AddForce((Random.insideUnitSphere + Vector3.up).normalized * force, ForceMode.Impulse);
            groundTile.enabled = false;
        }
    }
}
