using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsDistanceChange : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private float maxDelay;
    [SerializeField] private float Offset1;
    [SerializeField] private float Offset2;

    [SerializeField] Vector3 currentPSN;
    [SerializeField] Vector3 PSN1;
    [SerializeField] Vector3 PSN2;
    
    void Start()
    {
        currentPSN = transform.position;
        PSN1 = new Vector3(currentPSN.x, currentPSN.y, currentPSN.z - Offset1);
        PSN2 = new Vector3(currentPSN.x, currentPSN.y, currentPSN.z - Offset2);
    }
    void Update()
    {
        
        
        timer += Time.deltaTime;

        if (timer >= delay)
        {
         currentPSN = PSN1;
        }
        
        else if (timer <= delay)
        {
         currentPSN = PSN2;
        }
        if(timer >= maxDelay)
        {
            timer = 0;
        }
        transform.position = currentPSN;
    }
}
