using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    const float maxTime = 10f;
    public float currentTime = 0f;
    [SerializeField] CameraManager cameraManager;
    public bool dead = false;

    // UI
    [SerializeField] TextMeshProUGUI timer;

    private void Awake() 
    {
        instance = this;
        currentTime = maxTime;
    }

    private void Update() 
    {
        if(cameraManager.isInGame && currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            timer.text = currentTime.ToString("N2") + " s";
            
        }
        //  TODO : 플레이어 사망 로직 연결
        if(currentTime <= 0)
        {
            timer.text = "0 s";
            if(!dead)
            {
                dead = true;
                Martin.PlayerController.Instance.GameOver();
            }
                
        }
    }
}
