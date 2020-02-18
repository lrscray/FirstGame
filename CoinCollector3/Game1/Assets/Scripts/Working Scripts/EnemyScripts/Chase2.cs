using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase2 : MonoBehaviour
{
    private NavMeshAgent Enemy2;

    [SerializeField] private float chaseDistance = 4.0f;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Enemy2 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //defining distance in terms of badCoins and player
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //Chase after them if player gets too close
        if (distance < chaseDistance)
        {
            Vector3 changeDirection = transform.position - Player.transform.position;

            Vector3 newPosition = transform.position - changeDirection;

            Enemy2.SetDestination(newPosition);
        }
    }
}
