using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] spawnPoints;
    public float tempo;
    private float startTime;
    private float timer;

    void Update()
    {
        if(timer>tempo)
        {
            if (Random.Range(0,2) == 0)
            {
                LeftDab();
            } else 
            {
                RightDab();
            }
            
            timer -= tempo;
            
        }

        timer += Time.deltaTime;
    }

    void LeftDab()
    {
        GameObject topCube = Instantiate(cubes[0], spawnPoints[0]);
        GameObject bottomCube = Instantiate(cubes[1], spawnPoints[1]);
        topCube.transform.localPosition = Vector3.zero;
        topCube.transform.Rotate(transform.forward, 180);
        bottomCube.transform.localPosition = Vector3.zero;
        bottomCube.transform.Rotate(transform.forward, 180);
    }

    void RightDab()
    {
        GameObject topCube = Instantiate(cubes[0], spawnPoints[2]);
        GameObject bottomCube = Instantiate(cubes[1], spawnPoints[3]);
        topCube.transform.localPosition = Vector3.zero;
        topCube.transform.Rotate(transform.forward, 180);
        bottomCube.transform.localPosition = Vector3.zero;
        bottomCube.transform.Rotate(transform.forward, 180);
    }
}

