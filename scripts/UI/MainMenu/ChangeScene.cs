using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class ChangeScene {
    public enum scene{
        MainMenu,
        GameScene

    }
    
    public static void LoadNewScene( scene newScene){
        SceneManager.LoadScene(newScene.ToString());
       }
}
