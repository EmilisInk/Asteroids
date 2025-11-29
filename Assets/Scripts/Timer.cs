using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Start()
    {
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            float timeElapsed = Time.timeSinceLevelLoad;
            int minutes = Mathf.FloorToInt(timeElapsed / 60f);
            int seconds = Mathf.FloorToInt(timeElapsed % 60f);

            timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            StopAllCoroutines();
        }
    }
}
