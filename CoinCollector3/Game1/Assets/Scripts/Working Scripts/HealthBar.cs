using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image currentHP;
    public Text ratioText;

    [SerializeField] float hitpoint = 100;
    [SerializeField] float maxHitpoint = 100;

    private void Start()
    {
        UpdateHP();
    }

    //Update our HP bar. set the text to ratio times one hundred to see a change
    private void UpdateHP()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHP.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //*** NOTE TO SELF We don't want our text to show decimal values ***
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    private void TakeDamage(float damage)
    {   //set new hitpoint after damage reduction, apply death if hitpoint is <= zero
        hitpoint -= damage;
        //put a floor on damage
        if (hitpoint < 0)
        {
            hitpoint = 0;
            //this works but there is an issue here. mouse is still not active after scene is loaded
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //You need to free the cursor after locking it in game, Or you won't be able to click on the menu items
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("You Are Dead");
        }

        UpdateHP();
    }

    private void HealDamage(float heal)
    {
        //set new hitpoint (if neccesary) after heal
        hitpoint += heal;
        //put a cieling on "overheal"
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }

        UpdateHP();
    }
  

}
