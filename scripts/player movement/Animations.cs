using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D collider2D;
    void Awake(){
        animator = GetComponent<Animator>();
    }
    public void PlayAnimations(float direction,bool isJumping,bool isCrouching,bool isFalling){
        if(direction<0){
            Vector2 temp =transform.localScale;
            temp.x = -(Mathf.Abs(temp.x));
            transform.localScale = temp;
        }
        
        if(direction>0){
            Vector2 temp = transform.localScale;
            temp.x = Mathf.Abs(temp.x);
            transform.localScale = temp;
        }
        animator.SetFloat("speed",Mathf.Abs(direction));
        animator.SetBool("isJumping",isJumping);
        animator.SetBool("isCrouching",isCrouching);
        animator.SetBool("isFalling",isFalling);
        
    }
}
