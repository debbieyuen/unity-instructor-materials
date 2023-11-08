using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPractice : MonoBehaviour
{
    private float current, target;
    public float speed = 0.5f;
    void Start()
    {
        var myValue = Mathf.Lerp(0, 10, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (target == 0)
            {
                target = 1;
            }
            else
            {
                target = 0;
            }
        }
        // what ever we have now
        // a target
        // and a speed
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        Debug.Log(current);
    }
}
