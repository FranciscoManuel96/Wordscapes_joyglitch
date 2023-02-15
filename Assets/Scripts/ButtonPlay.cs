using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonPlay : MonoBehaviour
{
    public void LoadLevelOne()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Level1");
        
        //Reset score
        PlayerPrefs.SetInt("score", 0);
    }
}
