using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueLightAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collider){
        animator.SetBool("hasEntered",true);
        print("entered trigger statue light");
    }
    
}
