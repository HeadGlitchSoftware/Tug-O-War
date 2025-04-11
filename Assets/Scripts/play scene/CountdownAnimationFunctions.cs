using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAnimationFunctions : MonoBehaviour
{
    public void PlaySound(string soundName){
        AudioManager.Instance.PlaySFX(soundName);
    }

    public void StartGame(){
        GameManager.Instance.StartGame();
    }
}