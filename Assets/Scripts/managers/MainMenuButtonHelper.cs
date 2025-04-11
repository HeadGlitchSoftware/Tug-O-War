using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonHelper : MonoBehaviour
{
    public void LoadScene(string sceneName){
        SimpleSceneManager.Instance.LoadScene(sceneName);
    }
}
