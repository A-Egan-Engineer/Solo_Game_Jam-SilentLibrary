using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartButtonClicked);

        Button exitBtn = exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(OnExitButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
