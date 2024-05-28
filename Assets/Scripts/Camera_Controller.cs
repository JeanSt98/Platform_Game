using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPositiion = Vector3.Lerp(transform.position,desiredPosition,speed);
        //smoothPositiion.y = 0f;
        transform.position = smoothPositiion;
    }
    }
