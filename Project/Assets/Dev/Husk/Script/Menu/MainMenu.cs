using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        print("유니티에서는 종료 안된다 애송이");
        Application.Quit();
    }
}
