using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public bool isInGame;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
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

    public static void ChangeCam(Collider2D border, float lensSize)
    {
        if(instance.isInGame)
        {
            instance.TimeLineConfiner.m_BoundingShape2D = border;
            instance.isInGame = false;
            instance.TimelineCam.gameObject.SetActive(true);
            instance.InGameCam.gameObject.SetActive(false);

            instance.TimelineCam.m_Lens.OrthographicSize = lensSize;

            instance.ShakeCamera(0f, 0f);
        }
        else
        {
            instance.InGameConfiner.m_BoundingShape2D = border;
            instance.isInGame = true;
            instance.InGameCam.gameObject.SetActive(true);
            instance.TimelineCam.gameObject.SetActive(false);

            instance.InGameCam.m_Lens.OrthographicSize = lensSize;

            instance.ShakeCamera(0f, 0f);
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
