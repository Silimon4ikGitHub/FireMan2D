using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float maxHealth;
    public static float healthSend;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHealth;  
    }

    // Update is called once per frame
    void Update()
    {
        healthSend = HP;
    }
}
