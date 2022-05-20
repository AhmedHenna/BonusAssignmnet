using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private static List<GameObject> instances;
    private static int timeSeconds = 30;
    public static int currentSpawn = 0;
    private static long startTime = 0;
    private static long endTime = 0;


    public static void startGame(){
        if(instances != null){
                for(int i =0; i < instances.Count; i++){
                Destroy(instances[i]);
            }
        }
      startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
      endTime = startTime + (timeSeconds * 1000);
      instances = new List<GameObject>();
      currentSpawn = 0;
    }

    private void Start() {
     startGame();
    }

    
    // Update is called once per frame
    void Update()
    {
        long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        long remaining = endTime - now;


        if(remaining <= 0){
            for(int i =0; i < instances.Count; i++){
                Destroy(instances[i]);
            }
            Score.scoreString = "Game Over, Your Score is: " + Score.score.ToString();
            instances = new List<GameObject>();
        }

        while(currentSpawn < 5){
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-3,3),UnityEngine.Random.Range(2,5), UnityEngine.Random.Range(-3,3));
            GameObject instance  = Instantiate(cubePrefab,randomSpawnPosition,Quaternion.identity);
            instances.Add(instance);
            currentSpawn++;
        }
    }
}
