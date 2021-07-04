using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private void OnTriggerEnter2D(Collider2D collision){
        animator.SetBool("hasEntered",true);
    }
    private void OnTriggerExit2D(Collider2D collision){
        animator.SetBool("hasEntered" ,false);
    }
}
