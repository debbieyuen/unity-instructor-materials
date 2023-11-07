using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // make object point towards the object
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
        // look at returns a quaternion and takes in a vector 3
    }
}
