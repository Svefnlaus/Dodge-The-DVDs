using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject confirmationWindow;
    private bool isPaused;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape)) PauseGame();
    }

    public void QuitButton()
    {
        ResumeGame();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    protected void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        isPaused = true;
        confirmationWindow.SetActive(true);

        if (isPaused && Input.GetKeyUp(KeyCode.Escape)) ResumeGame();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        confirmationWindow.SetActive(false);
    }
}
