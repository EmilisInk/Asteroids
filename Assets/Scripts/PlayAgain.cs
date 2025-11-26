using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    public Button playAgainButton;

    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgainGame);
    }
    public void PlayAgainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
