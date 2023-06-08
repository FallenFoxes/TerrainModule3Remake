using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float steerSpeed = 20;
    public float jumpForce = 5f;
    public float shiftMultiplier = 3f;
    private bool isJumping = false;
    private bool isShiftPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        float steerValue = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float gasValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float jumpValue = Input.GetAxis("Jump") * jumpForce * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShiftPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isShiftPressed = false;
        }

        if (isShiftPressed)
        {
            gasValue *= shiftMultiplier;
        }

        Vector3 positionChange = Vector3.forward * gasValue;

        transform.Rotate(Vector3.up, steerValue);
        transform.Translate(positionChange);
        
    }

    private void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }
}
    

