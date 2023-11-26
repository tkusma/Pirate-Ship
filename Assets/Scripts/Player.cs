using UnityEngine;

public class Player : Ship
{
    [SerializeField] Transform frontCannon;
    [SerializeField] Transform centralCannon;
    [SerializeField] Transform rearCannon;

    private float inputY,inputX;

    override protected void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (!dead)
        {
            GetMoveInputs();

            if (Input.GetButtonDown("Shoot"))
                Shoot();

            if (Input.GetButtonDown("Shoot3Left"))
            {
                CannonRotate(90);
                TripleShoot();
            }
            if (Input.GetButtonDown("Shoot3Right"))
            {
                CannonRotate(-90);
                TripleShoot();
            }
        }
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (inputY > 0)
            rb.velocity = (transform.rotation * Vector2.up).normalized * velocity;
        else
            rb.velocity = Vector2.zero;

        rb.angularVelocity = angularVelocity * inputX;
    }

    void TripleShoot()
    {
        Instantiate(bullet, rearCannon.position, rearCannon.rotation);
        Instantiate(bullet, centralCannon.position, centralCannon.rotation);
        Instantiate(bullet, frontCannon.position, frontCannon.rotation);
    }

    void CannonRotate(float alfa)
    {
        rearCannon.localEulerAngles = new (0, 0, alfa);
        centralCannon.localEulerAngles = new(0, 0, alfa);
        frontCannon.localEulerAngles = new Vector3(0, 0, alfa);
    }

    void GetMoveInputs()
    {
        inputY = Input.GetAxisRaw("Vertical");
        inputX = -Input.GetAxisRaw("Horizontal");
    }
}
