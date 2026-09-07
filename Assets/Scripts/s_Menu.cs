using UnityEngine;
using UnityEngine.SceneManagement;

public class s_Menu : MonoBehaviour
{

    public GameObject globalMenu;
    public GameObject mainMenu;
    public GameObject pauseMenu;

    void Start()
    {
        globalMenu.SetActive(true);
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void StartLevel()
    {
        globalMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void PauseMenu() //Called by event
    {
        globalMenu.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void PlayGame()
    {
        globalMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OptionsMenu()
    {
        //Needs Review
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToMenu()
    {
        //Solo si queremos que el Exit de PauseMenu regrese al incio
    }
}
