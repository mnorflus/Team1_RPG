using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 target_position = new Vector3(target.position.x, target.position.y, transform.position.z);

            target_position.x = Mathf.Clamp(target_position.x, minPosition.x, maxPosition.x);
            target_position.y = Mathf.Clamp(target_position.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, 
                                                target_position,
                                                smoothing);
        }
    }
}
