using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class Camerafollow : MonoBehaviour
{
    public Transform target;
    private void FixedUpdate()
    {
        transform.position = target.position + new Vector3(0,0,-1);
    }
}
