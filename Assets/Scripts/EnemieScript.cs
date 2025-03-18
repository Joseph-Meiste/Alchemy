using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitColliders;
    private RaycastHit hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody rb;
    public GameObject Target;

    private bool seePlayer;

    void Start()
    {
        Speed = MaxSpeed;
    }

    void Update()
    {
        if (!seePlayer)
        {
            // Check if player is within detection range
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    Target = hitCollider.gameObject;
                    seePlayer = true;
                    break; // Exit loop once player is found
                }
            }
        }
        else
        {
            // Raycast to check if player is in sight
            if (Physics.Raycast(transform.position, (Target.transform.position - transform.position).normalized, out hit, SightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Move towards the player
                    MoveTowardsPlayer();
                }
                else
                {
                    // Lost sight of the player
                    seePlayer = false;
                }
            }
            else
            {
                // No hit, check if the player is in range
                seePlayer = false;
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the direction to the target and move the enemy towards it
        Vector3 direction = (Target.transform.position - transform.position).normalized;
        Vector3 targetVelocity = direction * Speed;

        // Smooth the movement using MoveTowards for more natural movement
        rb.velocity = Vector3.MoveTowards(rb.velocity, targetVelocity, Speed * Time.deltaTime);
    }
}
