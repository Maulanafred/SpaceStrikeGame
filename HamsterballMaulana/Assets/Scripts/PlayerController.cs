using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedWithKeyboard;
    public float swipeSpeed;

    public LayerMask collisionLayerMask; // Layer mask to specify which layers to check for collisions

    private Transform playerTransform;
    private Rigidbody rb;

    private Vector3 lastMousePosition;
    private Vector3 mousePos;

    private bool usingKeyboardControl = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent rotation if not needed
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is using the keyboard or mouse
        if (Input.GetAxis("Horizontal") != 0)
        {
            usingKeyboardControl = true;
        }
        else
        {
            usingKeyboardControl = false;
        }

        // Control the player based on the input device
        if (usingKeyboardControl)
        {
            // If using the keyboard, hide the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ControlWithKeyboard();
        }
        else
        {
            // If using the mouse, show the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ControlWithMouse();
        }
    }

    private void ControlWithMouse()
    {
        // Get the current mouse position
        mousePos = Input.mousePosition;

        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Calculate the difference in mouse position from the center along the x-axis
        float XDiff = (mousePos.x - screenCenter.x) / screenCenter.x;

        // Create a movement vector based on the x-axis difference
        Vector3 movement = new Vector3(XDiff, 0, 0) * swipeSpeed * Time.deltaTime;

        // Raycast to check for collisions
        if (!Physics.Raycast(playerTransform.position, movement, movement.magnitude, collisionLayerMask))
        {
            // If no collision, move the player
            rb.MovePosition(playerTransform.position + new Vector3(movement.x, 0, 0));
        }
        else
        {
            // If collision, stop the player's movement
            rb.MovePosition(playerTransform.position);
        }

        // Update the last mouse position
        lastMousePosition = mousePos;
    }

    private void ControlWithKeyboard()
    {
        // Get input from the arrow keys or WASD keys
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0, 0) * speedWithKeyboard * Time.deltaTime;

        // Raycast to check for collisions
        if (!Physics.Raycast(playerTransform.position, movement, movement.magnitude, collisionLayerMask))
        {
            // If no collision, move the player
            rb.MovePosition(playerTransform.position + movement);
        }
        else
        {
            // If collision, stop the player's movement
            rb.MovePosition(playerTransform.position);
        }
    }
}
