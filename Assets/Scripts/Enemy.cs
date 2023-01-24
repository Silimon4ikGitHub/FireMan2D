using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("GM Enemy Normal Warrior")]
    [SerializeField] private GameObject EnemyNormalWarrior;

    [Header ("Attack Parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private bool changeAttack;
    [SerializeField] private bool triggerToAttackWizzard;
    [SerializeField] private bool triggerToAttackBandit;
    public static bool triggerToAttackSend;

    [Header ("Health Parameters")]
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private EnemyHealthBar healthBar;
    public static float enemyHealthSend;

    [Header ("Attack Parameters")]
    [SerializeField] private float damage; 
    [SerializeField] private float coolDownTimer = Mathf.Infinity;
    [SerializeField] private Animator anim;

    [Header ("Scripts")]
    [SerializeField] private Wizzard wizzardScript;
    [SerializeField] private AliedBandit banditScript;

    [Header ("Bonus Appear Parameters")]
    [SerializeField] private GameObject skullPrefab;
    [SerializeField] private Vector3 skullPSN;
    [SerializeField] private float skullOffset;
    
     
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        enemyHealthSend = enemyMaxHealth;
        healthBar.SetHealth(enemyHealth, enemyMaxHealth);
        
         
    }

    void Update()
    {
        // ============ Health Bar =============
        healthBar.SetHealth(enemyHealth, enemyMaxHealth);

        // =========== Attack CoolDown timer ============
        coolDownTimer += Time.deltaTime;
       
        // =========== Send Variable to Make Damage ============
        if (triggerToAttackBandit == true | triggerToAttackWizzard == true)
        {
            triggerToAttackSend = true;
        }
        else
        {
            triggerToAttackSend = false;
        }

        //============== WHEN ATTACK ==============
            if(coolDownTimer >= attackCoolDown && triggerToAttackWizzard == true && changeAttack == false)
            {
                coolDownTimer = 0;
                anim.SetTrigger("enemyAttack1");   
                changeAttack = !changeAttack;
            }
            else if(coolDownTimer >= attackCoolDown && triggerToAttackWizzard == true && changeAttack == true)
            {
                coolDownTimer = 0;
                anim.SetTrigger("enemyAttack2");
                changeAttack = !changeAttack;
            }
            if(coolDownTimer >= attackCoolDown && triggerToAttackBandit == true && changeAttack == false)
            {
                coolDownTimer = 0;
                anim.SetTrigger("enemyAttack1");  
                Debug.Log("Enemy Trigger is Working3");
                changeAttack = !changeAttack;
            }
            if(coolDownTimer >= attackCoolDown && triggerToAttackBandit == true && changeAttack == true)
            {
                coolDownTimer = 0;
                anim.SetTrigger("enemyAttack2");  
                Debug.Log("Enemy Trigger is Working4");
                changeAttack = !changeAttack;
            }
             //============== DEATH ================
            if (enemyHealth <= 0)
            {
            anim.SetTrigger("die");
            }

    // =============When Attack Blue==============
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            triggerToAttackWizzard = true; 
              
                     
        } 
        if (collision.CompareTag("blue"))
        {
            triggerToAttackBandit = true;
            banditScript = collision.GetComponentInParent<AliedBandit>();   
                     
        } 
        
    }
    private void OnTriggerExit2D(Collider2D collision) 
    { 
        
        if(collision.CompareTag("Player"))
        {
            triggerToAttackWizzard = false;
        }
        if (collision.CompareTag("blue"))
        {
            triggerToAttackBandit = false;   
                     
        }
        
    }
    private void GiveDamage()
    {
        if (triggerToAttackBandit == true)
        {
            banditScript.TakeDamage(damage);
        }
        else if(triggerToAttackWizzard == true)
        {
            wizzardScript.WizzardTakeDamage(damage);
        }
        
        Debug.Log("Wizzard Take Damage");
    
    }
    
    public void TakeDamage(float takingDamage)
    {
        enemyHealth = enemyHealth - takingDamage;
        
        return;
    }
    
    private void EnemyDeath()
    {
        skullPSN = new Vector3(transform.position.x, transform.position.y - skullOffset, transform.position.z);
        
        Instantiate(skullPrefab, skullPSN, transform.rotation);
        Destroy(EnemyNormalWarrior);
        
    }  
}
