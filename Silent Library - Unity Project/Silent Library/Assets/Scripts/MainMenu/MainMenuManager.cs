using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        Debug.Log("Start Button Clicked!");
        // Add logic to start the game
    }
}
