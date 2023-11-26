using UnityEngine;

public class Shooter : Ship
{
    [SerializeField] float detectionRadius = 2.5f;
    [SerializeField] float shootingRange = 2f;

    private float shotClock=0;

    override protected void Start()
    {
        base.Start();
        target = GameManager.manager.Player.transform;
    }

    protected override void FixedUpdate()
    {
        if (!dead)
            if (Vector2.Distance(target.position,transform.position) < detectionRadius)
            {
                if (shotClock <= 0)
                {
                    AimAndShoot();
                    shotClock = shootingRange;
                }
                else
                    shotClock -= Time.fixedDeltaTime;
            }
            else
                Follow();
    }

    void AimAndShoot()
    {
        rb.velocity = Vector2.zero;
        Vector2 direction = target.position - transform.position;
        transform.up = direction.normalized;
        Shoot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
