using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerController : MonoBehaviour
{
    private float playerSpeed, xInput, zInput, xSensitivity = 100f, ySensitivity = 100f;
    private float mouseX, mouseY;

    float xRotation = 0;
    private bool playerMove;

    Rigidbody rb;
    public  Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = 250;
    }

    public void FixedUpdate()
    {
        // player rotation
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);

        // ROTATION ALONG THE X AXIS

        //  mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;
        //  xRotation -= mouseY; // -= bcos i want the rotation along the x axis to correspond with my mouse position (up and down)
        //  xRotation = Mathf.Clamp(xRotation, -80, 80);
        //   cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // player movement
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        Vector3 move = (xInput * transform.right) + (zInput * transform.forward); // setting direction
        rb.velocity = new Vector3(move.x * (playerSpeed * Time.deltaTime), rb.velocity.y, move.z * (playerSpeed * Time.deltaTime));
    }
}
