using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform turgetToGO;
    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float runCoolDown;
    private float runCoolDownTimer;
    private float speedTrue;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    [Header ("Animator")]
    [SerializeField] private Animator runAnimation;
    private Vector3 initScale;
    private int dirrection;
    private bool movingLeft;
    

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    
    void Update()
    { 
      runCoolDownTimer += Time.deltaTime;
        
        //following Player
        if(movingLeft & runCoolDown < runCoolDownTimer )
        {
          
          
          if(enemy.position.x >= leftEdge.position.x & Enemy.triggerToAttackSend == false)
          {
            MoveInDirection(-1);
          }
          else 
          {
            ChangeDirrection();
          }
        }
        else
          {
            
            if(enemy.position.x <= rightEdge.position.x & Enemy.triggerToAttackSend == false)
            {
                MoveInDirection(1);
            }
            else
            {
                ChangeDirrection();
            }

          }
          //Stop when attack
        if(Enemy.triggerToAttackSend == true)
        {
          Stop();
        }
        
    }
    private void MoveInDirection( int dirrection)
    {
      speedTrue = speed;
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -dirrection, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * dirrection * speedTrue, enemy.position.y, enemy.position.z);
        runAnimation.SetBool("moving", true);
    }
    private void ChangeDirrection()
    {
        movingLeft = !movingLeft;
        runAnimation.SetBool("moving", false);
        
        
    }
    public void Stop() 
      {
        speedTrue = 0;
        runAnimation.SetBool("moving", false);
        runCoolDownTimer = 0;

      }
    
}
