using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXinput, mouseYinput;
    [SerializeField] private float mouseSensitivity = 120.0f;
    [SerializeField] private Transform playerBody;

    //we need to clamp how far the camera can rotate
    [SerializeField] private float xAxisClamp;

    //Lock the cursor at the center of the screen as soon as the game starts
    //remember to press ESC key to see cursor again!
    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        //get input of mouse on the x and y axis
        float mouseX = Input.GetAxis(mouseXinput) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYinput) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        //Check rotation of the camera is 10 or -20 from the original position
        // *** commenting this out because it is unnecesary at this moment, I don't want player to be able to look up and down but keeping it here for future Ideas***
        /*if(xAxisClamp > 10.0f)
        {
            xAxisClamp = 10.0f;
            mouseY = 0.0f;         
        }
        else if (xAxisClamp < -20.0f)
        {
            xAxisClamp = -20.0f;
            mouseY = 0.0f;
        }

        //pass in the amount you want to rotate the camera. 
        transform.Rotate(Vector3.left * mouseY); */

        //Allows Camera to look horizontally in relation to a given object
        //Drag and drop playerBody into this in Unity
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
