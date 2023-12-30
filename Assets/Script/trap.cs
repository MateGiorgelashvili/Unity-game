using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] private GameObject trap1;
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trap1.GetComponent<Collider2D>().isTrigger = true;
    }
}
