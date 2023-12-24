using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public AudioSource univSound;

    //Speed at which the player moves.
    public float speed = 0;
    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;
    // UI object to display winning text.
    public GameObject winTextObject;

    //for the deactivation of the door
    [SerializeField] GameObject door;
    [SerializeField] GameObject nextLevel;
    

    //Rigidbody of the player.
    private Rigidbody rb;
    // Variable to keep track of collected "PickUp" objects.
    private int count;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;


    //Movement along X and Y axis.
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        //Get and store the Rigidbody component attached to the player.
       rb = GetComponent<Rigidbody>();
       // Initialize count to zero.
       count = 0;
       // Update the count display.
       SetCountText();
       // Initially set the win text to be inactive.
       winTextObject.SetActive(false);

       nextLevel.SetActive(false);

       jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue) 
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText() 
    { 
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 12) 
        {
            // Display the win text.
            winTextObject.SetActive(true);
            
            Time.timeScale = 0;

            nextLevel.SetActive(true);
        }
    }

    void OnCollisionStay()
    	{
    		isGrounded = true;
    	}

    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate() 
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) 
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("Pickup")) 
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            // Increment the count of "PickUp" objects collected.
            count = count + 1;
            // Update the count display.
            SetCountText();
            
            univSound.Play();
        }
        if (other.gameObject.CompareTag("FakePickup")) 
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
        }
    }

    void Update() 
    {
        //makes the door disappear after 4 pick ups are collected
        if (count==4) 
        {
            door.SetActive(false);
        } 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
    		rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    		isGrounded = false;
    	}
    }
} 



