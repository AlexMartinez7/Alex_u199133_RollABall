using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 
 private int count;

 public AudioClip pickUpSound; 
 public AudioClip boostSound;

 public AudioClip pipeSound;

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;

 // Speed at which the player moves.
 public float speed = 0; 
 
 private Vector3 RespawnPos;
 
 public float boostForce = 500f;
 public TextMeshProUGUI countText; // Reference to the UI text element to display the count.
 public GameObject winTextObject; // Reference to the UI text element to display the win message.

 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        RespawnPos= new Vector3(0,0.5f,0);
        count = 0; // Initialize the count variable.
        SetCountText(); // Update the UI text to display the initial count.
        winTextObject.SetActive(false); // Hide the win text at the start.
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

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
 // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

 // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed); 

    // Check if the player is below a certain height
        if (transform.position.y < -5.0f)
        {
            // Reset the player's position to the RespawnPos.
            transform.position = RespawnPos; 
            rb.velocity = Vector3.zero; // Reset the Rigidbody's velocity.
        }
    }

 void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp")) // Check if the collided object has the "Pickup" tag.
        {
            
            other.gameObject.SetActive(false); // Deactivate the object the player collides with.
            count++; // Increment the count variable.
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position); // Play the pickup sound at the player's position.
            SetCountText(); // Update the UI text to reflect the new count.
        }
        else if (other.CompareTag("Booster")){
            Vector3 boostDirection = new Vector3(0, 0.5f, 1).normalized;
            AudioSource.PlayClipAtPoint(boostSound, transform.position,3.0f);
            rb.AddForce(boostDirection * boostForce, ForceMode.Impulse);
        }
        else if (other.CompareTag("Tuberia"))
        {   
            AudioSource.PlayClipAtPoint(pipeSound, transform.position);
            GameObject salida = GameObject.FindGameObjectWithTag("TuberiaSalida");
            if (salida != null)
        {
            Vector3 posicionSalida = salida.transform.position + Vector3.up * 1f;
            
            transform.position = posicionSalida;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        }
    }
 void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // Update the UI text to display the current count.
        if (count >= 39) 
        {
            winTextObject.SetActive(true); // Show the win text.
        }
    }
}