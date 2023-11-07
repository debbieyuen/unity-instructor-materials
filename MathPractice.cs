using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class MathPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Componentwise Vector Multiply
    // Means you have 2 vectors, x, y, and z components
    // want to multiply the x component in each result
    void ComponentwiseVectorMultiplyClassic()
    {
        // Create vector number 1
        var v0 = new Vector4(2.0f, 4.0f, 6.0f, 8.0f);
        // Create vector number 2
        var v1 = new Vector4(1.0f, -1.0f, 1.0f, -1.0f);
        // Call the vector of this scale
        var result = Vector4.Scale(v0, v1);
        // result == new Vector4(2.0f, -4.0f, 6.0f, -8.0f).
    }

    void ComponentwiseVectorMultiplyUnityMathematics()
    {
        // Create vector number 1
        var v0 = new float4(2.0f, 4.0f, 6.0f, 8.0f);
        // Create vector number 2
        var v1 = new float4(1.0f, -1.0f, 1.0f, -1.0f);
        // Now we don't need to call a specific function
        // call operator multiply

        var result = v0 * v1;
        // result == new Vector4(2.0f, -4.0f, 6.0f, -8.0f).
    }

    //Build 4x4 Matrix
    void Build4x4Classic()
    {
        // Create 4 vector4s each one represents a column in your matrix
        var c0 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        var c1 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
        var c2 = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
        var c3 = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        // feed in those vectors into your matrix into your 4x4 constructor
        var m = new Matrix4x4(c0, c1, c2, c3);
    }
    void Build4x4UnityMathematics()
    {
        // Create 4 vector4s each one represents a column in your matrix
        var c0 = new float4(1.0f, 0.0f, 0.0f, 0.0f);
        var c1 = new float4(0.0f, 1.0f, 0.0f, 0.0f);
        var c2 = new float4(0.0f, 0.0f, 1.0f, 0.0f);
        var c3 = new float4(0.0f, 0.0f, 0.0f, 1.0f);
        // feed in those vectors into your matrix into your 4x4 constructor
        var m = new float4x4(c0, c1, c2, c3);
    }

    // Quaternion multiplication
    // you have some sort of orientation and
    // you want to alter that orientation by rotating it
    // about some axis
    // here we have rotate about 45 degrees at the up axis
    void QuaternionMultiplicationClassic()
    {
        // define the up axis
        var axis = Vector3.up;
        // call quaternion and provide the angle axis and degrees
        // q is the qua ation rotation
        var q = Quaternion.AngleAxis(45.0f, axis);
        // give it some rotation
        var orientation = Quaternion.Euler(45.0f, 90.0f, 180.0f);
        // in order to rotate the axis around 45 degrees
        // quatation quaaternion * the rotation 
        var result = q * orientation;
    }
    void QuaternionMultiplicationUnityMathematics()
    {
        // no more vector ups
        // define our own vector
        var axis = new float3(0.0f, 1.0f, 0.0f);
        // provide the axis
        // most things in mathematics is expected to be in radians
        // classic unit is in degrees
        // once i have this i have the quatation quaternion q 
        var q = quaternion.AxisAngle(axis, math.radians(45.0f));
        var orientation = quaternion.Euler(
            math.radians(45.0f),
            math.radians(90.0f),
            math.radians(180.0f));
        // operator multiplier is not going to give you the result we need
        // math.mul does the actual multiplication
        var result = math.mul(q, orientation);
    }

    // Generating random numbers
    void RandomNumberClassic()
    {
        // access the static property, unityengine random value
        // that gives you a random float between 0 and 1 inclusive
        // means you can get the endpoints 0 and 1
        // 0 and 1 are possible to be returned
        // [0, 1] inclusive
        float randomFloat1 = UnityEngine.Random.value;

        // you can also specify your range
        // inclusiveness is important if you care about randomness in game
        // [-5, 5] inclusive
        float randomFloat2 = UnityEngine.Random.Range(-5.0f, 5.0f);
    }

    void RandomNumberUnityMathematics()
    {
        // Choose some non-zero seed and set up
        // the random number generator state
        // instead of accessing a global static property
        // you need to m aintain your own state
        // your own random number generator state

        // can separate random generators
        uint seed = 1;
        Unity.Mathematics.Random rng = new Unity.Mathematics.Random(seed);

        // [0, 1) exclusive
        // you can never get 1 back in this call
        float randomFloat1 = rng.NextFloat();

        // [-5, 5) exclusive
        // supply your own
        float randomFloat2 = rng.NextFloat(-5.0f, 5.0f);
    }
}
