using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float strength = 4;

    [SerializeField]  public float maxSpeed = 5f;

    [SerializeField] public float minVelocity = 3;
    [SerializeField] public float maxVelocity = 7;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);
    }
}
