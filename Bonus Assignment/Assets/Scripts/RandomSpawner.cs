using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private static List<GameObject> instances;
    private static int timeSeconds = 30;
    public static int currentSpawn = 0;
    private static long startTime = 0;
    private static long endTime = 0;
    private Text timeText;
    AudioSource gameover;
    public static string timeString = "";
    private static bool gameOverPlayed = false;



    public static void startGame(){
        if(instances != null){
                for(int i =0; i < instances.Count; i++){
                Destroy(instances[i]);
            }
        }
        gameOverPlayed = false;
      startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
      endTime = startTime + (timeSeconds * 1000);
      instances = new List<GameObject>();
      currentSpawn = 0;
    }

    private void Start() {
     startGame();
     gameover = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
     timeText = GameObject.FindGameObjectWithTag("Tag2").GetComponent<Text>();
    }

    
    void Update()
    {
        long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        long remaining = endTime - now;
        long currentRemain = remaining/1000;
        if(currentRemain >= 0){
            timeString = "Time Remaining: " + currentRemain;
        }
        
        timeText.text = timeString; 


        if(remaining <= 0)
        {
            for(int i =0; i < instances.Count; i++){
                Destroy(instances[i]);
            }
            Score.scoreString = "Game Over, Your Score is: " + Score.score.ToString();
            Debug.Log("Going to play");
            if(!gameOverPlayed){
                gameover.Play();
                gameOverPlayed = true;
            }
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
