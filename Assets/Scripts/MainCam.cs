using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    [SerializeField] private Transform trackingObject;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(trackingObject.position.x, transform.position.y, transform.position.z);
    }
}
