using System.Collections;
using UnityEngine;

public class explosive : MonoBehaviour
{
    public playerData Data;
    [SerializeField] private float rawExplosionForce;
    private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float rawLaunchPower;
    private float launchPower;
    [SerializeField] private float launchAngle;


    private void OnValidate()
    {
        explosionForce = rawExplosionForce * 50;
        launchPower = rawLaunchPower * 50;
    }

    void FixedUpdate()
    {
        if (Data.explosionInput == true)
            Explode();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerExplode();

        else if (collision.gameObject.CompareTag("Enemy"))
            Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force = force * 0.2f;

                rb.AddExplosionForce(force, transform.position, explosionRadius);

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath();
                }
            }
        }
        Destroy(gameObject);
    }

    private void playerExplode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && !rb.gameObject.CompareTag("Player"))
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force = force * 0.2f;

                rb.AddExplosionForce(force, transform.position, explosionRadius);
                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>(); 
                    enemy.triggerDeath();
                }
            }
            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                float angleRad = Mathf.Deg2Rad * launchAngle;
                Vector3 launchDirection = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0).normalized;
                rb.AddForce(launchDirection * launchPower, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }

}
