using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private Text ScoreText;
    //NOTE TO SELF: Coins are using a box Collider.

    //NOTE TO SELF: Make sure to set "isTrigger" to "ON" in the Coin prefab!
    void Update()
    {
        if (Score >= 13)
        {
            Winner();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Be sure to set player tag to "Player"
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        AddScore();
    }

    void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

    void Winner()
    {
        ScoreText.text = "Nice Job!";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //You need to free the cursor after locking it in game, Or you won't be able to click on the menu items
        Cursor.lockState = CursorLockMode.None;
        //Freezes game once you win. Just here for testing
        //Time.timeScale = 0f;
    }
}
