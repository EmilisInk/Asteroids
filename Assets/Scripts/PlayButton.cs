using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
    void OnPlayButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
