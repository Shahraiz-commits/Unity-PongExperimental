using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    void Start(){
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused) ResumeGame();
            else PauseGame();
        }
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMenu(){
        // Resume time
        Time.timeScale = 1f;
        //Loads main menu
        SceneManager.LoadScene("MainMenu");
       //FindObjectOfType<AudioManager>().Play("bg music 1");
    }

    // Quits application
    public void Quit(){
        //FindObjectOfType<AudioManager>().Stop("Bad Snacks - Easy Sunday");
        Debug.Log("Game closed!");
        Application.Quit();
    }
    
}