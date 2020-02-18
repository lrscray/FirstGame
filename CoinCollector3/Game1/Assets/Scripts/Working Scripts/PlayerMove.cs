using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Note to self: your character will fall due to gravity, freeze constraints in rigidBody to fix
    [SerializeField] public float speed = 5.0f;
    [SerializeField] public string horizontalInput;
    [SerializeField] public string verticalInput;

    private CharacterController charController;

    //Cool way to manipulate character movement
    [SerializeField] private AnimationCurve fallCurve;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpkey;

    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //get input for x and y axis
        float hori = Input.GetAxis(horizontalInput) * speed; //no need to multiply by Time.deltaTime (Look at lines 41 + 42)
        float vert = Input.GetAxis(verticalInput) * speed; //no need to multiply by Time.deltaTime (Look at lines 41 + 42)

        Vector3 forwardMovement = transform.forward * vert;
        Vector3 sideMovement = transform.right * hori;

        //SimpleMove automatically applies Time.deltaTime
        charController.SimpleMove(forwardMovement + sideMovement);

        Jumping();
    }


    private void Jumping()
    {
        //when user presses key, jump if character is not already jumping
        if(Input.GetKeyDown(jumpkey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        //set variable with initial time in the air
        float timeAirborn = 0.0f;

        do
        {
            float jumpForce = fallCurve.Evaluate(timeAirborn);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeAirborn += Time.deltaTime; 
            yield return null;
        }
        while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above); //in case the character jumps underneath an object or low cieling

        isJumping = false;
    }
}
