using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinTrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("die", 0.1f);
        }
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
