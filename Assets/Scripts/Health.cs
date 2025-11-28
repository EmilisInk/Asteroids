using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health--;
            Spawner.spawnCount--;
            healthText.text = "Health: " + health.ToString();
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                //Spawner.spawnCount--;
                healthText.text = "Health: 0";
                HandleGameOver();
            }
            
        }
        
    }

    private async void HandleGameOver()
    {
        await Task.Delay(2000);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
