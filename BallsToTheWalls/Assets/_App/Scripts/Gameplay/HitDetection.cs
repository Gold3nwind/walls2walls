using System;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] public float minVelocity = 1;
    [SerializeField] public float maxVelocity = 20;

    [SerializeField] public float hitThreshold = 0.5f;
    [SerializeField] public float timeThresholdSeconds = 1f;

    [SerializeField] public GameObject ball;

    [SerializeField] public long lastHitInSeconds;

    [SerializeField] public Transform hitPoint1;
    [SerializeField] public Transform hitPoint2;
    [SerializeField] public Transform centerPoint;

    [SerializeField] public float power = 5f;

    private DateTime? lastHitAt;

    private void Update()
    {
        if (ShouldDetectCollision())
        {
            lastHitAt = DateTime.Now;
            lastHitInSeconds = lastHitAt.Value.Ticks / 1000;

            // Determine hit direction based on your logic
            Vector3 hitDirection = DetermineHitDirection();

            // Apply hit force
            ApplyHitForce(hitDirection);
        }
    }

    private bool ShouldDetectCollision()
    {
        // Check distance
        if (Vector3.Distance(transform.position, ball.transform.position) < hitThreshold)
        {
            // Perform a raycast to ensure collision detection, especially for fast movements
            RaycastHit hit;
            if (Physics.Raycast(transform.position, ball.transform.position - transform.position, out hit, hitThreshold))
            {
                if (hit.collider.gameObject == ball && TimeSinceLastHitExceededThreshold())
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool TimeSinceLastHitExceededThreshold()
    {
        return lastHitAt == null || (DateTime.Now - lastHitAt.Value).TotalSeconds > timeThresholdSeconds;
    }

    private Vector3 DetermineHitDirection()
    {
        // Implement your logic to determine the hit direction based on hitPoint1 and hitPoint2
        // For example, you can compare distances or use a predefined direction.
        Vector3 direction = hitPoint1.position - hitPoint2.position;
        direction.Normalize();
        return direction;
    }


    private void ApplyHitForce(Vector3 hitDirection)
    {
        // Apply force to the ball for a more realistic response
        ball.GetComponent<Rigidbody>().velocity = hitDirection * CalculateHitForce();
    }

    private float CalculateHitForce()
    {
        // You can customize the force calculation based on your requirements
        return power;
    }
}
