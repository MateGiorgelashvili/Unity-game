using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinTrap : MonoBehaviour
{

    Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Anim.Play("death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
