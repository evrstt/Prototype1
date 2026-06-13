using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    // our speed and rotation speed had no values so this is what was making us fly super fast (in addition to the missing delta time) and in a loop
    public float speed = 20.0f;
    public float rotationSpeed = 45.0f;
    public float verticalInput;

    
    void Start()
    {

    }

    
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Vector3 was previously set to back, changed to forward and was also missing Time.deltaTime so it was doing this on every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // these are inverted when in the game window (W = down, S = up), I didn't adjust these as it didn't specifically state it was a bug or something I needed to solve
        // and that's how a  plane's tail rotor functions either way.
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
