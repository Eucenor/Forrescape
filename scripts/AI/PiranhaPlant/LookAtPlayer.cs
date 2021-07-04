using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update(){
        float dir = transform.position.x - player.position.x;
        if(Mathf.Sign(dir)>=0){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
        else{
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*-1,transform.localScale.y,transform.localScale.z);
        }
    }
}
