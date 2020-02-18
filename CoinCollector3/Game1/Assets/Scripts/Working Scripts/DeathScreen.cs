using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void RestartGame()
    {
        //Launches the previous scene (the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void backtoMain()
    {
        //Launches the the Main Menu scene for the user.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}
