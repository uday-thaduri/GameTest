using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public Text resultText;
    public Image bgImage;
    public GameObject replayBtn;
    public GameObject quitBtn;
    public Text statusText;

    private void Start()
    {
        bgImage.enabled = false;
        replayBtn.SetActive(false);
        quitBtn.SetActive(false);
    }

    public void Loose()
    {
        resultText.text = "Looser";
        bgImage.enabled = true;
        replayBtn.SetActive(true);
        quitBtn.SetActive(true);
    }

   public void Win()
    {
        resultText.text = "Winner";
        bgImage.enabled = true;
        replayBtn.SetActive(true);
        quitBtn.SetActive(true);
    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteAll();
    }

    public void QuitBtn()
    {
        Application.Quit();

    }

    public void StausText(string t)
    {
        statusText.text = t;
    }
}
