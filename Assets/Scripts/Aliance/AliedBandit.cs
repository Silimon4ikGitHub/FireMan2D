using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliedBandit : MonoBehaviour
{
    [SerializeField] private float banditHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private bool triggerToAttack;
    [SerializeField] private Animator banditAnimator;
    [SerializeField] private Enemy CurrentEnemyScript;
    public static bool triggerToAttackToSend;
    private float coolDownTimer;
    
    


    
    
    void Start()
    {
        banditHealth = maxHealth;
        banditAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        triggerToAttackToSend = triggerToAttack;
        // ===============Timer for Attack Cooldown============
        coolDownTimer += Time.deltaTime;
        
        if (banditHealth <= 0)
        {
            banditAnimator.SetTrigger("Death");

        }
        
        //==============Attack==============
        if (triggerToAttack == true && coolDownTimer >= attackCoolDown)
        {
            banditAnimator.SetTrigger("Attack");
            coolDownTimer = 0;
        }
        

    }
    
    public void TakeDamage(float takingDamage)
    {
        banditHealth = banditHealth - takingDamage;
    }
    private void BanditDie()
    {
        
        Destroy(gameObject);

    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.GetComponent<WarriorBody>())
        {
            triggerToAttack = true;
            
            CurrentEnemyScript = collision.GetComponentInParent<Enemy>();
        }
        else
        {
            triggerToAttack = false;
        }
        
    }
     
    public void GiveDamage()
    {
        CurrentEnemyScript.TakeDamage(damage);

    }

    public void BanditLeave()
    {
        DataHolder.QttyOfBandits ++;
        Destroy(gameObject);
    }
    
    public void ColliderOff()
    {
        CapsuleCollider2D caps = GetComponentInChildren<CapsuleCollider2D>();
        caps.enabled = false;
    }
}
