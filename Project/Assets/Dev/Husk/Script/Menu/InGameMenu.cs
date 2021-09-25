using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        Timer.instance.currentTime = 0;
    }
}
