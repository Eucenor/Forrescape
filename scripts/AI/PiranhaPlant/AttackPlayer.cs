using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Animator animator;
    private void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Player")
        {
            playerHealth.TakeDamage();
            animator.SetBool("isHurt",true);
        }
    }
    private void OnTriggerExit2D(){
        animator.SetBool("isHurt",false);
    }
}
