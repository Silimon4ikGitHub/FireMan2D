
using UnityEngine;

public class WizzardBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D banditBody;
    [SerializeField] private CapsuleCollider2D banditCollider;
    [SerializeField] private CapsuleCollider2D playerCollider;
    

    //[SerializeField] private LayerMask banditLayer;
    //[SerializeField] private LayerMask playerLayer;
    private void Start() 
    {
        banditCollider = gameObject.GetComponent<CapsuleCollider2D>();
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }
    private void OnCollisionEnter2D (Collision2D collision) 
    {
        
        
        if(collision.gameObject.GetComponent<BanditBody>())
        {
            Debug.Log("this shit is working!!");
            
            //banditCollider = collision.gameObject.GetComponent<CapsuleCollider2D>();
            
            //Physics2D.IgnoreCollision(banditCollider, playerCollider, true);
        }
    }
    
}
