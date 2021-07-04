using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool hasEntered = false;
    private void Update(){
        anim.SetBool("hasEntered" , this.hasEntered);
    }
     private void OnTriggerStay2D(Collider2D col){
        hasEntered = true;
     }
    private void OnTriggerExit2D(Collider2D col){
        hasEntered = false;

    }

}
