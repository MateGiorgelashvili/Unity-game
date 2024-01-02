using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    bool secondLap = false;
    [SerializeField] float moveSpeed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 14)
        {
            secondLap = true;
        }
        if(transform.position.x <= -1)
        {
            secondLap = false;
        }

        if (secondLap)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        
    }
}
