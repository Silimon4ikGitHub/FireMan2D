using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Wizzard : MonoBehaviour
{
    [SerializeField] private float speedForce;
    // ======FOR JUMP=======
    //[SerializeField] private float jumpForce;
    //[SerializeField] private bool isGround;
    [SerializeField] private bool triggerToDamage;
    [SerializeField] private int skullScore;
    [SerializeField] private float maxHealth;
    [SerializeField] private float wizzardHealth;
    [SerializeField] private float damage;
    [SerializeField] private float fireballRotationOffset;
    [SerializeField] Vector3 position;
    [SerializeField] HealthBar healthBar;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField]private TMP_Text skullScoreText;
    [SerializeField]private TMP_Text Text;
    [SerializeField] private CapsuleCollider2D banditCollider;
    [SerializeField] private CapsuleCollider2D playerCollider;
    [SerializeField] private GameObject fireballPrefab;
    public static float healthSend;
    private Animator wizzardAnimator;
    private SpriteRenderer spriteRend;
    public static Transform wizzardPSN;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        wizzardAnimator = GetComponent<Animator>();
        banditCollider = gameObject.GetComponentInChildren<CapsuleCollider2D>();
        playerCollider = gameObject.GetComponentInChildren<CapsuleCollider2D>();
        healthSend = maxHealth;
    }

    private void Awake() 
    {
        skullScore = DataHolder.QttyOfSkulls;
    }

    void Update()
    {
        
        healthBar.SetHealth(healthSend, maxHealth);
        
        wizzardHealth = healthSend;
        wizzardPSN = gameObject.transform;
        player = wizzardPSN;
         if (Input.GetKeyDown("escape"))
    {
        Escape();
    }
     if(Input.GetKeyDown("r"))
        {             
            ShootFireBall();
        }
    // ======FOR JUMP=======

        //if (Input.GetKeyDown("space"))
        //{
        //    Jump();
        //} 
    }

   
    void FixedUpdate()
    {
        //===============Navigation===========
        position = transform.position;
        

        //==============Moution==============
        position.x += Input.GetAxis("Horizontal") * speedForce;
        transform.position = position;

        if (Input.GetAxis("Horizontal") > 0)
        {
            player.localScale = new Vector3(Mathf.Abs(player.localScale.x) * 1, player.localScale.y, player.localScale.z);
            wizzardAnimator.SetInteger("state", 1);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            player.localScale = new Vector3(Mathf.Abs(player.localScale.x) * -1, player.localScale.y, player.localScale.z);
            wizzardAnimator.SetInteger("state", 1);
        }
        else
        {
            wizzardAnimator.SetInteger("state", 0);
        }
        // ===============Attack=============
        if(Input.GetKey("space"))
        {
            Attack();
        }
        else
        {
        wizzardAnimator.SetBool("attack", false);
        }
    }
    // ======FOR JUMP=======

    //private void Jump()
    //{
    //    if(isGround)
    //    {
    //        isGround = false;
    //        playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    //    }
    //}

    //Is Ground ?
    //private void OnCollisionEnter2D(Collision2D collision) 
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGround = true;
    //    }
    // }

    // ======TRIGGER TO DAMAGE  ENEMY=======
    private void OnTriggerStay2D(Collider2D collision) 
    {  
        if (collision.GetComponent<WarriorBody>() && Input.GetKey("space"))
        {           
                collision.GetComponentInParent<Enemy>().TakeDamage(damage);     
        }   
    }
    private void OnTriggerExit2D(Collider2D collision) 
    { 
        if(collision.GetComponent<WarriorBody>())
        {
            triggerToDamage = false;
        }
    }

    // ===========Ignore Bandit Collider===========
    private void OnCollisionEnter2D (Collision2D collision) 
    {
        
        
        if(collision.gameObject.GetComponent<AliedBandit>())
        {
            
            
            banditCollider = collision.gameObject.GetComponentInChildren<CapsuleCollider2D>();
            
            Physics2D.IgnoreCollision(banditCollider, playerCollider, true);
        }
    }
    public void AddSkull(int count)
    {
        skullScore += count;
        skullScoreText.text = skullScore.ToString();
        DataHolder.QttyOfSkulls = skullScore;
    }
    
    private void Attack()
    {
            wizzardAnimator.SetBool("attack", true);
    }
    private void ShootFireBall()
    {
        var fireballRotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z + fireballRotationOffset, transform.rotation.w);
        Instantiate(fireballPrefab, transform.position, fireballRotation);
    }
    public void WizzardTakeDamage(float takingDamage)
    {
        healthSend = healthSend - takingDamage;
    }
    private void Escape()
    {
        SceneManager.LoadScene(0);
    }
}
