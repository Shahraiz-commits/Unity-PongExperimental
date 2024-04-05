using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void playGame(){
        //Loads next scene in queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       //FindObjectOfType<AudioManager>().Play("bg music 1");
    }

    // Quits application
    public void Quit(){
        FindObjectOfType<AudioManager>().Stop("Bad Snacks - Easy Sunday");
        Debug.Log("Game closed!");
        Application.Quit();
    }
    
}