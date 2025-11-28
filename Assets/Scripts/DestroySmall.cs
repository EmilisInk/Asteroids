using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmall : MonoBehaviour
{
    public int scoreAmmountSmall = 5;
    public AudioSource destroySound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(destroySound.clip, transform.position, 0.2f);
            ScoreManager.Instance.AddScore(scoreAmmountSmall);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
