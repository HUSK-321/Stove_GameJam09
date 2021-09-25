using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    [SerializeField] CameraManager cameraManager;

    Vector3 nextPos;
    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        
        if(cameraManager.isInGame)
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    // public void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     }
    // }
}
