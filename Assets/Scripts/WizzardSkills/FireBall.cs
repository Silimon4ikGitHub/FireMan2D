using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] Wizzard wizzardScript;
    [SerializeField] Transform fireBallPosition;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
