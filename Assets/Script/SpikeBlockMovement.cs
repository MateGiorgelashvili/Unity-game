using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlockMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject spike1;
    [SerializeField] private GameObject spike2;
    [SerializeField] private GameObject spike3;
    private float yPosOfSpike = 0;
    public int moveSpeed = 2;
    private bool secondLap;

    // Update is called once per frame
    void Update()
    {
        if(yPosOfSpike >= 4)
        {
            secondLap = true;
        }

        if(yPosOfSpike <= 0)
        {
            secondLap = false;
        }


        if (secondLap)
        {
            yPosOfSpike -= moveSpeed * Time.deltaTime;
        }
        else
        {
            yPosOfSpike += moveSpeed * Time.deltaTime;
        }
        


        
        spike1.transform.position = new Vector3(91f, yPosOfSpike, 0);
        spike2.transform.position = new Vector3(95.5f, FindOpposite(yPosOfSpike, 0, 4), 0);
        spike3.transform.position = new Vector3(100f, yPosOfSpike, 0);

    }
    static float FindOpposite(float inputValue, int rangeMin, int rangeMax)
    {
        if (rangeMin > rangeMax)
        {
            int temp = rangeMin;
            rangeMin = rangeMax;
            rangeMax = temp;
        }

        float opposite = rangeMax - inputValue;
        return opposite;
    }
}
