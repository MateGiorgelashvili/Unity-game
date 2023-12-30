using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] private GameObject trap1;
    [SerializeField] private GameObject snowDisapear;
    AudioSource audioSource;
    void Update()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(trap1);
        GameObject.Destroy(snowDisapear);
        Invoke("batoninika", 0.8f);

    }

    void batoninika()
    {
        audioSource.Play();
    }
}
