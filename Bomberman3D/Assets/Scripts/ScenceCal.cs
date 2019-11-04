using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceCal : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
        
    }
    public void QuitBtn()
    {
        Application.Quit();
       
    }
}
 