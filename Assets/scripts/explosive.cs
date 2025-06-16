using UnityEngine;

public class explosive : MonoBehaviour
{
    public playerData Data;
    private bool explodable;
    [SerializeField] private float rawExplosionForce;
    private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float rawLaunchPower;
    private float launchPower;
    [SerializeField] private float launchAngle;


    private void Start()
    {
        explosionForce = rawExplosionForce * 50;
        launchPower = rawLaunchPower * 50;
    }

    void FixedUpdate()
    {
        if (Data.explosionInput == true)
        {
            Data.explosionInput = false;
            if (explodable)
                Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerExplode();

        else if (collision.gameObject.CompareTag("Enemy"))
            Explode();

        else if (collision.gameObject.CompareTag("Ground")) // Add this condition
        {
            explodable = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            Data.cantThrow = false;
        }

        else
            explodable = false;
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
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange);

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
        Data.cantThrow = false;
        Rigidbody myRb = GetComponent<Rigidbody>();
        if (myRb != null)
        {
            Destroy(myRb);
            GetComponent<Collider>().enabled = false;
        }


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
                    force = force * 0.7f;
                

                rb.AddExplosionForce(force, transform.position, explosionRadius);
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange);

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath();
                }
            }
            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                float angleRad = Mathf.Deg2Rad * launchAngle;

                // Calculate the forward direction the player is facing
                Vector3 flatForward = rb.transform.forward;
                flatForward.y = 0f;
                flatForward.Normalize();

                // Upward component from angle
                float yComponent = Mathf.Sin(angleRad);
                float horizontalComponent = Mathf.Cos(angleRad);

                // Final launch direction — in the direction the player is facing, angled upward
                Vector3 launchDirection = (flatForward * horizontalComponent + Vector3.up * yComponent).normalized;

                float finalPower = launchPower;
                if (Data.isDashing)
                    finalPower *= 0.8f;

                rb.AddForce(launchDirection * finalPower, ForceMode.VelocityChange);
            }
        }
        Destroy(gameObject);
    }

}
