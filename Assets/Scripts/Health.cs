using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText;
    public AudioSource deathSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health--;
            deathSound.Play();
            Spawner.spawnCount--;
            healthText.text = "Health: " + health.ToString();
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                healthText.text = "Health: 0";
                HandleGameOver();
            }
        }
    }

    private void HandleGameOver()
    {
        Timer.Instance.StopTimer();

        GameObject go = new GameObject("GameOverHandler");
        GameOverHandler handler = go.AddComponent<GameOverHandler>();
        handler.StartCoroutine(handler.GameOverRoutine(deathSound.clip.length));

        Destroy(gameObject);
    }
}

public class GameOverHandler : MonoBehaviour
{
    public IEnumerator GameOverRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }
}
