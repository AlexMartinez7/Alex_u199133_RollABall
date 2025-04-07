using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Vector3 offset; // Offset from the player position
    public float smoothSpeed = 0.125f; // Speed of the camera movement
    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position - player.transform.position; // Calculate the initial offset
    }

    // Update is called once per frame
    void Update()
    {
       transform.position= Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed); // Smoothly move the camera to the new position 
    }
}
