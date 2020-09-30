using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5f,20f)]
    public float speed = 10f;

    void Start()
    {
      
    }
    void Update()
    {
        transform.Translate(GetInput().normalized*speed*Time.deltaTime);

    }

    Vector3 GetInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            p_Velocity += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            p_Velocity += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            p_Velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            p_Velocity += Vector3.right;
        }

        return p_Velocity;
    }
}
