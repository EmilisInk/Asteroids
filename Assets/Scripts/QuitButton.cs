using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
