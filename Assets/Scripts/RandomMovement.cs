using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        /*var y = Random.Range(min, max);*/
        var z = Random.Range(min, max);
        return new Vector3(x, 0, z);
    }

    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(1f, 1f);
    }
}
