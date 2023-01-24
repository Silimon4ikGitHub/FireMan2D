using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
    [SerializeField] private GameObject banditPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 2; i ++)
        {
        Instantiate(banditPrefab, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
