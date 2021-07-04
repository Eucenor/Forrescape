using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasGameObject;
    public void QuitThisGame()
    {
        canvasGameObject.SetActive(false);
        Application.Quit();
    }
}
