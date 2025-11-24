using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int scoreAmmountBig = 10;
    public GameObject toSpawnPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instance.AddScore(scoreAmmountBig);
            Spawner.spawnCount--;
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(toSpawnPrefab, transform.position, transform.rotation);
        }
    }
}
