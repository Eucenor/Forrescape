using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.SetActive(true);
    }
}
