using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    AttackPlayer attack;
    SpriteRenderer piranaColor;
    Color inactiveColor;
    Color activeColor;
    Anims anims;
    private void Start()
    {
        attack = GetComponentInChildren<AttackPlayer>();
        piranaColor = GetComponent<SpriteRenderer>();
        activeColor = piranaColor.color;
        anims = GetComponent<Anims>();
        inactiveColor = new Color(piranaColor.color.r, piranaColor.color.g, piranaColor.color.b, 157); 
    }
    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "slug"){
            attack.enabled = false;
            anims.enabled = false;
            piranaColor.color = inactiveColor;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        piranaColor.color = activeColor;
        attack.enabled = true;
        anims.enabled = true;
    }
}
