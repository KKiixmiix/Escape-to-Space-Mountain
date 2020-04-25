// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)
 
using UnityEngine;
using System.Collections;
 
// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 0f;
    public float amplitude = 0.5f;
    public float frequency = 0.1f;
    public float multiplier = 3f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {   
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down in a spiral
        tempPos = transform.position;
        //tempPos = posOffset;
        tempPos.x = posOffset.x + Mathf.Cos(Time.fixedTime * Mathf.PI * (multiplier * frequency)) * amplitude;
        tempPos.y = posOffset.y + Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * (multiplier * amplitude);
        tempPos.z = posOffset.z + Mathf.Sin(Time.fixedTime * Mathf.PI * (multiplier * frequency)) * amplitude;

        // Frenetic fly motion
        //tempPos.x += Random.value - .5f;
        //tempPos.z += Random.value - .5f;
        // Random fly motion
        //tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * (Random.value - .5f)) * amplitude;
        //tempPos.z += Mathf.Sin(Time.fixedTime * Mathf.PI * (Random.value - .5f)) * amplitude;

        transform.position = tempPos;
    }
}