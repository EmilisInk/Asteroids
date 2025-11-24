using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmall : MonoBehaviour
{
    public int scoreAmmountSmall = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instance.AddScore(scoreAmmountSmall);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
