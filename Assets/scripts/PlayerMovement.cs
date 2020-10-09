using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5f,20f)]
    public float speed = 10f;
    private Animator anim;
    [Range(10f,100f)]
    public AnimationCurve objScale;
    float timer, lerpTime = 3f;
    Vector2 scale, endScale = new Vector3(2,2,1);
    void Start()
    {
        scale = transform.localScale;
        anim = GetComponent<Animator>();
      
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lerpTime)
        {
            timer = lerpTime;
        }
        float lerpRatio = timer / lerpTime;
        transform.localScale = Vector3.Lerp(scale,endScale,lerpRatio);
        Vector3 movement = GetInput();
        transform.Translate(movement.normalized*speed*Time.deltaTime);
        anim.SetFloat("MoveX",movement.x);
        anim.SetFloat("MoveY",movement.y);

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
