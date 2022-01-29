using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Level0");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
