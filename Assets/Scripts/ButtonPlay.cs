using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonPlay : MonoBehaviour
{
    public void LoadLevelOne()
    {
        //Reset score
        PlayerPrefs.SetInt("score", 0);
        
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Level1");
    }
}
