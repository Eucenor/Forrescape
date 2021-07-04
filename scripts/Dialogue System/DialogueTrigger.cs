using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;
    public void BeginDialogue()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        if(dm){
            print("yes");
        }
        else{
            print("no");
        }
        dm.StartDialogue(this.dialogue);
    }

    
    // Update is called once per frame
    
}
