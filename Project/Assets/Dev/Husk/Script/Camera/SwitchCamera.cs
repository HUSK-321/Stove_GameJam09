using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] PolygonCollider2D IngameConfiner;
    [SerializeField] PolygonCollider2D TimelineConfiner;
    [SerializeField] CameraManager cameraManager;


    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(cameraManager.isInGame && !cameraManager.tabbed)
            {
                cameraManager.ChangeCam(TimelineConfiner);
            }
            else
            {
                cameraManager.ChangeCam(IngameConfiner);
            } 
        }
    }

    
}
