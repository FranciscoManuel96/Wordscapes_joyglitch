using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonPlay : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("level", 1);
    }
}
