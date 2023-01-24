using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBonus : MonoBehaviour
{
   [SerializeField] private int count;

   [SerializeField] private AudioClip audioClip;
   [SerializeField] private AudioSource audioSource;
   [SerializeField]private GameObject player;
   [SerializeField]private Animator skullAnim;
  
    

   private void Start() 
   {
    player = GameObject.FindGameObjectWithTag("Wizzard");
    audioSource = player.GetComponent<AudioSource>();
    
   }
   private void Awake() 
   {
      
      
      Debug.Log("Skull Awake");
   }
   

private void OnTriggerEnter2D(Collider2D collision) 
   {
      if (collision.GetComponent<WizzardBody>())
      {
         player.GetComponent<Wizzard>().AddSkull(count);
         audioSource.PlayOneShot(audioClip);
         Debug.Log("SkullTrigger is working");
         Destroy(gameObject);
      }
   }
}
