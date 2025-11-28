using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int scoreAmmountBig = 10;
    public GameObject toSpawnPrefab;
    public AudioSource destroySound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            destroySound.PlayOneShot(destroySound.clip, 0.2f);
            if (!destroySound.isPlaying)
            {
                ScoreManager.Instance.AddScore(scoreAmmountBig);
                Spawner.spawnCount--;
                Destroy(gameObject);
                Destroy(other.gameObject);
                Instantiate(toSpawnPrefab, transform.position, transform.rotation);
            }

        }
    }
}
