using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // 씬 빌드 인덱스++;
            if(nextSceneIndex >= Application.levelCount)
                SceneManager.LoadScene(0);
            else 
                SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
