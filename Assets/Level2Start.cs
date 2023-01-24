using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
    [SerializeField] private GameObject banditPrefab;
    [SerializeField] private Wizzard wizzardScript;
    [SerializeField] private Vector3 offset;
    
    void Start()
    {
        Instantiate(banditPrefab, transform.position, transform.rotation);
        Instantiate(banditPrefab, transform.position + offset, transform.rotation);
        wizzardScript.AddSkull(10);
    }
}
