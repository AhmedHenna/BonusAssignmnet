using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0; 
    private Text scoreText;
    public static string scoreString = "";

    private void Start() {
        scoreText = GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision other) {
       if(other.collider.tag == "Target"){
           score++;
           scoreString = "Your Score: " + score;
           RandomSpawner.currentSpawn--;
           Destroy(other.gameObject);
       }
    }

   public int getScore(){
       return score;
   }

    void Update() {
       scoreText.text = scoreString;
   }
   
}
