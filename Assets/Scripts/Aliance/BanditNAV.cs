using UnityEngine;
using System.Collections;

public class BanditNAV : MonoBehaviour 
{

    [SerializeField] float      m_speed;
    [SerializeField] float      m_speedTrue;
    [SerializeField] float     idleDuration;
    [SerializeField] float  idleTimer;
    [SerializeField] Transform  banditPSN;
    [SerializeField] AliedBandit  banditScript;
    
   
    

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
   

    // Use this for initialization
    void Start () {
        m_animator = GetComponentInParent<Animator>();
        m_body2d = GetComponentInParent<Rigidbody2D>();
        
    }
    
	// Update is called once per frame
	void Update () 
    {
        idleTimer += Time.deltaTime;
        
        
        if(AliedBandit.triggerToAttackToSend == true)
        {
            Stop();
        }
        else if (AliedBandit.triggerToAttackToSend == false && idleTimer >= idleDuration)
        {
            Moving();
        }
    }
    public  void Stop() 
    {
        {
        m_speed = 0;
        m_animator.SetBool("Moving", false);  
        idleTimer = 0;   
        }
    }
    public void Moving()
    {
        m_speed = m_speedTrue;
        banditPSN.position = new Vector3(banditPSN.position.x + Time.deltaTime * m_speed, banditPSN.position.y, banditPSN.position.z);
        m_animator.SetBool("Moving", true);
        
    }
}
