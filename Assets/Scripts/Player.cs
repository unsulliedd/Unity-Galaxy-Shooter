using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Set the player's position to the origin
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        FireLaser();
    }

    void PlayerMovement()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set the boundaries for the player
        float VerticalBoundary = 4.0f;
        float HorizontalBoundary = 11.2f;

        // Create a vector based on the input
        Vector3 inputDirection = new(horizontalInput, verticalInput, 0);

        // Move the player based on input
        transform.Translate(_speed * Time.deltaTime * inputDirection);

        // Clamp the player's position vertically
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -VerticalBoundary, VerticalBoundary), 0);

        // Wrap the player's position horizontally
        if (transform.position.x > HorizontalBoundary)
        {
            transform.position = new Vector3(-HorizontalBoundary, transform.position.y, 0);
        }
        else if (transform.position.x < -HorizontalBoundary)
        {
            transform.position = new Vector3(HorizontalBoundary, transform.position.y, 0);
        }
    }
    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
