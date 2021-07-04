using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMovement : MonoBehaviour
{
     private Vector3 leftOffset ;
     private Vector3 rightOffset ;
     [SerializeField] private float PatrolDistance = 5;
     private bool reachedLeft = false;
     private bool reachedRight = true;
     [SerializeField] private float speed = 3;
    void Start()
    {
        leftOffset = new Vector3(
                                    transform.position.x - PatrolDistance,
                                    transform.position.y,
                                    transform.position.z
                                );
        rightOffset = new Vector3(
                                    transform.position.x + PatrolDistance,
                                    transform.position.y,
                                    transform.position.z
                                );
        Turn("left");
    }
    void Update(){

        MoveLeft();
        MoveRight();
        
    }
    
    private void Turn(string dir){
        if(dir == "left"){
            transform.localScale = new Vector3(
                                                Mathf.Abs(transform.localScale.x),
                                                transform.localScale.y,
                                                transform.localScale.z
                                            );  
        }
        else{
                 transform.localScale = new Vector3(
                                                Mathf.Abs(transform.localScale.x)*-1,
                                                transform.localScale.y,
                                                transform.localScale.z
                                            );  
        }
    }
    
    void MoveLeft(){
        if(!reachedLeft){
            transform.position = Vector3.MoveTowards(transform.position,leftOffset,speed * Time.deltaTime);
            if(transform.position.x <= leftOffset.x){
                reachedLeft = true;
                reachedRight = false;    
                Turn("right");
            }
        
        }
    }
    void MoveRight(){
        if(!reachedRight){
            transform.position =  Vector3.MoveTowards(transform.position,rightOffset,speed * Time.deltaTime);
            if(transform.position.x >= rightOffset.x){
                reachedLeft = false;
                reachedRight = true;
                Turn("left");
            }
        }
    }
}
