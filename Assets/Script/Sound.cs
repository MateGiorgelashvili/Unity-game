using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private bool isFirst = true;
    AudioSource audioSource;
    void Update()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst)
        {
            kaichemo();
            isFirst = false;
        }
        
    }

    void kaichemo()
    {
        audioSource.Play();
    }

}
