using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    private const float G = 6.67f;
    public static List<Attractor> pAttractors;

    void AttractorFormular(Attractor other)
    {
        //F = G * ((m1 * m2) / d^2)
        Rigidbody rbOther = other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;
        float forceMegnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance,2);
        Vector3 forceDir = direction.normalized * forceMegnitude;
        rbOther.AddForce(forceDir);
    }
    void FixedUpdate()
    {
        foreach (var attractor in pAttractors)
        {
            if (attractor != this)
            {
                AttractorFormular(attractor);
            }
        }
    }
    private void OnEnable()
    {
        if (pAttractors == null)
        {
            pAttractors = new List<Attractor>();
        }
        pAttractors.Add(this);
    }
}
