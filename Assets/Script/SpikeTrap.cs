using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isTrapActivated = false;

    void Start()
    {
        // Store the initial position of the trap
        initialPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTrapActivated)
        {
            // Trigger the trap
            isTrapActivated = true;
            RaiseTrap();
        }
    }

    void RaiseTrap()
    {
        // You can customize the height of the trap rising
        float targetHeight = 0.5f; // Adjust this value based on how high you want the trap to rise

        // Set the trap's position instantly
        transform.position = initialPosition + Vector3.up * targetHeight;

        // Reset the scene after the trap has risen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
