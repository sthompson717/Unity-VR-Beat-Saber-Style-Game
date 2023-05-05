using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    AudioSource audioSource;
    public int sceneID;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!audioSource.isPlaying){
            // This is attached to the music in the game
            MoveToScene(sceneID);
        }
    }
    
    public void MoveToScene(int sceneID){
        // This is attached to the buttons in the menu
        SceneManager.LoadScene(sceneID);
    }
}
