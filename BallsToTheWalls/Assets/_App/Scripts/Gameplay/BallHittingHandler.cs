using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHittingHandler : MonoBehaviour
{
    public float hitForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Calculate force based on racket's velocity and direction
            Vector3 forceDirection = transform.forward; // Use the racket's forward vector
            float force = hitForce * Mathf.Clamp(Vector3.Dot(forceDirection, collision.relativeVelocity.normalized), 0f, 1f);

            // Apply force to the ball
            collision.rigidbody.AddForce(forceDirection * force, ForceMode.Impulse);
        }
    }
}
