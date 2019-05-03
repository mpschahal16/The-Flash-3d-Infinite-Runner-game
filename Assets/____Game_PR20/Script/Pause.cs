using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject ScoreUi;
    public GameObject deathUi;
    public GameObject lavel_change_Ui;
    public GameObject deathtimer_ui;

    public static bool pauseMenuVisible = false;
    public static bool scoreUiVisible = true;
    public static bool deathMenuVisible = false;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&!deathUi.active)
        {
            if(pauseMenuVisible)
            {
                resume();
            }
            else
            {
                deathtimer_ui.SetActive(false);
                pause();
            }
        }
        
    }
    public void resume()
    {
        Debug.Log("resume");
        pauseMenuUI.SetActive(false);
        ScoreUi.SetActive(true);
        Time.timeScale = 1f;
        pauseMenuVisible = false;
        scoreUiVisible = true;


    }
    void pause()
    {
        Debug.Log("pause");
        pauseMenuUI.SetActive(true);
        ScoreUi.SetActive(false);
        Time.timeScale = 0f;
        pauseMenuVisible = true;
        scoreUiVisible = false;
    }
    public void StartAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("base_scene");
    }
    public void BacktoMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("initial_scene");
    }
    public void ExitGame()
    {
        Debug.Log("Quit_game");
        Application.Quit();
    }
}
