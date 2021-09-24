using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CameraManager : MonoBehaviour
{
    // -6.5 -14.55
    // 8
    // 14.5

    public bool isInGame;
    float shakeTimer;
    float totalShakeTimer;
    float startingIntensity;
    [SerializeField] CinemachineVirtualCamera InGameCam;
    [SerializeField] CinemachineVirtualCamera TimelineCam;

    [Header("UI 관련")]
    public bool tabbed;
    [SerializeField] GameObject UI;
    [SerializeField] TextMeshProUGUI tabCountUI;
    void Awake()
    {
        isInGame = true;
        tabbed = false;
    }

    public void ChangeCam()
    {
        if(isInGame && !tabbed)
        {
            isInGame = false;
            UI.SetActive(false);
            tabbed = true;
            tabCountUI.text = "You Can't Tab!";
            TimelineCam.gameObject.SetActive(true);
            InGameCam.gameObject.SetActive(false);


            //ShakeCamera(0f, 0f);
        }
        else
        {
            isInGame = true;
            UI.SetActive(true);
            InGameCam.gameObject.SetActive(true);
            TimelineCam.gameObject.SetActive(false);


            //ShakeCamera(0f, 0f);
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin multiChannelPerlin;
        if(isInGame)
        {
            multiChannelPerlin = InGameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else 
        {
            multiChannelPerlin = TimelineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        multiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        totalShakeTimer = time;
        shakeTimer = time;
    }

    private void Update() 
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {   
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
                if(isInGame)
                {
                    cinemachineBasicMultiChannelPerlin = InGameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                }
                else
                {
                    cinemachineBasicMultiChannelPerlin = TimelineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                }
                
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, (1 - (shakeTimer / totalShakeTimer)));
            }
        }
    }
}


/*



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public bool isInGame;
    float shakeTimer;
    float totalShakeTimer;
    float startingIntensity;
    [SerializeField] CinemachineVirtualCamera InGameCam;
    [SerializeField] CinemachineVirtualCamera TimelineCam;
    public CinemachineConfiner InGameConfiner;
    public CinemachineConfiner TimeLineConfiner;
    void Awake()
    {
        instance = this;
        isInGame = true;
    }

    public void ChangeCam(Collider2D border)
    {
        if(instance.isInGame)
        {
            instance.TimeLineConfiner.m_BoundingShape2D = border;
            instance.isInGame = false;
            instance.TimelineCam.gameObject.SetActive(true);
            instance.InGameCam.gameObject.SetActive(false);


            //instance.ShakeCamera(0f, 0f);
        }
        else
        {
            instance.InGameConfiner.m_BoundingShape2D = border;
            instance.isInGame = true;
            instance.InGameCam.gameObject.SetActive(true);
            instance.TimelineCam.gameObject.SetActive(false);


            //instance.ShakeCamera(0f, 0f);
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin multiChannelPerlin;
        if(isInGame)
        {
            multiChannelPerlin = InGameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else 
        {
            multiChannelPerlin = TimelineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        multiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        totalShakeTimer = time;
        shakeTimer = time;
    }

    private void Update() 
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {   
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
                if(isInGame)
                {
                    cinemachineBasicMultiChannelPerlin = InGameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                }
                else
                {
                    cinemachineBasicMultiChannelPerlin = TimelineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                }
                
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, (1 - (shakeTimer / totalShakeTimer)));
            }
        }
    }
}


*/