using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void backtoMain()
    {
        //Launches the the Main Menu scene for the user.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
