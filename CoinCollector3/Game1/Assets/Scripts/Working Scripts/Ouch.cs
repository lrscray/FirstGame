using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouch : MonoBehaviour
{
    public bool doesDamage;
    public float damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player takes damage upon collision.
            other.SendMessage(doesDamage? "TakeDamage" : "HealDamage", Time.deltaTime * damage * 1000);
            Destroy(gameObject);
        }
    }
           
}
