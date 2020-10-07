using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
float timeLeft;
Color targetColor;
 void Start()
 {
     
 }
void Update()
{
  if (timeLeft <= Time.deltaTime)
  {
    // transition complete
    // assign the target color
    GetComponent<SpriteRenderer>().material.color = targetColor;
 
    // start a new transition
    targetColor = new Color(Random.value, Random.value, Random.value);
    timeLeft = 1.0f;
  }
  else
  {
    // transition in progress
    // calculate interpolated color
    GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, targetColor, Time.deltaTime / timeLeft);
 
    // update the timer
    timeLeft -= Time.deltaTime;
  }
}}
