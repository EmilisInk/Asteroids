using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public TextMeshProUGUI timerText;
    private TextMeshProUGUI finalTimeText;

    private float totalTime;

    private bool isRunning = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void Update()
    {
        if(!isRunning)
            return;

        totalTime += Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = GetFormattedTime();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().name == "MainGame")
        {
            timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();

            ResetTimer();
        }


        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            finalTimeText = GameObject.Find("TimePlayed").GetComponent<TextMeshProUGUI>();
            if (finalTimeText != null)
            {
                finalTimeText.text = "Final Time: " + GetFormattedTime();
            }
        }
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60F);
        int seconds = Mathf.FloorToInt(totalTime % 60F);
        int milliseconds = Mathf.FloorToInt((totalTime * 100F) % 100F);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void ResetTimer()
    {
        totalTime = 0f;
        isRunning = true;

        if (timerText != null)
        {
            timerText.text = GetFormattedTime();
        }
    }
}
