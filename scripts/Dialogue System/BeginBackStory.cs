using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginBackStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogueTrigger>().BeginDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
