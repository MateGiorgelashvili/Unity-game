using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sound : MonoBehaviour
{

    AudioSource audioSource;
    void Update()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kaichemo();
    }

    void kaichemo()
    {
        audioSource.Play();
    }

}
