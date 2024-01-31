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
    public float jumpForce;

    Rigidbody rb;
    public  Camera cam;

    [SerializeField] private bool isMoving;
    Animator anim;
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

        zInput = Mathf.Clamp(zInput, 0, 1000000);

        Vector3 move = (xInput * transform.right) + (zInput * transform.forward); // setting direction
        rb.velocity = new Vector3(move.x * (playerSpeed * Time.deltaTime), rb.velocity.y, move.z * (playerSpeed * Time.deltaTime));

        // jump mechanic
        if (Input.GetKey(KeyCode.Space)) rb.AddForce(Vector2.up * jumpForce);
    }
}
