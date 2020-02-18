using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 80.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed, 0f, 0f) * Time.deltaTime);
    }
}
