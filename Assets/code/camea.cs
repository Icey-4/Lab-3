using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camea : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1f, -2.0f);

    private Transform target;


    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
