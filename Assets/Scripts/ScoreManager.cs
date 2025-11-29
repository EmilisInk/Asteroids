using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    int score = 0;

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
        }
    }

    public void AddScore(int ammount)
    {
        score += ammount;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

            ResetScore();
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            TextMeshProUGUI finalScoreText = GameObject.Find("FinalScore").GetComponent<TextMeshProUGUI>();
            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + score.ToString();
            }
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }


}
