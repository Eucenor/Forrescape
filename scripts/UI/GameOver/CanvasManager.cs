using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
   [SerializeField] private Health h1;
    void Start()
    {
        h1 = GameObject.FindGameObjectWithTag("player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if((h1.getCurrentHealth()) <= 0)
        {
            gameObject.SetActive(true);
        }
    }
}
