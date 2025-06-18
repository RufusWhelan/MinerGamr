using UnityEngine;

public class explosive : MonoBehaviour
{
    public playerData Data { get; set; }
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
            // if the explosive can explode, explode it.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Checks if the explosive hit the player, an enemy or the ground.
        Args:
            collision (collision): the collider of what the projectile hit

        'Returns':
`              none
        */

        if (collision.gameObject.CompareTag("Player"))
            playerExplode(); // trigger a special kind of explosion if the explosive collides with player

        else if (collision.gameObject.CompareTag("Enemy"))
            Explode(); // trigger normal explosion

        else if (collision.gameObject.CompareTag("Ground"))
        {
            explodable = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            Data.cantThrow = false;
        } //if the explosive hits the ground, it can now explode and is frozen in position

        else
            explodable = false;
    }
    private void Explode()
    {
        /*
        If the explosive collides with
        */
        Data.cantThrow = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //search through nearby colliders
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0)
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0)
                    force = force * 0.2f;
                //modify the force applied if the object is travelly up or down

                rb.AddExplosionForce(force, transform.position, explosionRadius); //apply force to nearby colliders
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange); // send the collided objects up a little bit

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath(); //calls a method of the ai class
                } //if the explosion hits an enemy, destroy it.
            }
        }
        Destroy(gameObject);
    }

    private void playerExplode()
    {
        Data.cantThrow = false; // allow throwing again since explosion happened
        Rigidbody myRb = GetComponent<Rigidbody>();
        if (myRb != null)
        {
            Destroy(myRb); // remove rigidbody so explosive doesn’t collide with the player and change the launch direction
            GetComponent<Collider>().enabled = false; // disable collider so no more collisions
        }


        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //search through nearby colliders
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && !rb.gameObject.CompareTag("Player"))
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) 
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0)
                    force = force * 0.7f;
                     //modify the force applied if the object is travelly up or down

                
                rb.AddExplosionForce(force, transform.position, explosionRadius); // apply force to nearby colliders
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange); // send the collided objects up a little bit

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath(); //calls a method of the ai class
                } //if the explosion hits an enemy, destroy it.
            }
            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                float angleRad = Mathf.Deg2Rad * launchAngle;

                Vector3 flatForward = rb.transform.forward;
                flatForward.y = 0f;
                flatForward.Normalize();

                float yComponent = Mathf.Sin(angleRad);
                float horizontalComponent = Mathf.Cos(angleRad);
                Vector3 launchDirection = (flatForward * horizontalComponent + Vector3.up * yComponent).normalized;
                //uses pythagoras theorem to determine the to send the player forwards at 

                float finalPower = launchPower;
                if (Data.isDashing)
                    finalPower *= 0.8f; // reduce force if player is dashing

                rb.AddForce(launchDirection * finalPower, ForceMode.VelocityChange); // launch player forward at angle
            }
        }
        Destroy(gameObject); // remove explosive after explosion
    }

}
