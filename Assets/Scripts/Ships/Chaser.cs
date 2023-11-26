using UnityEngine;

public class Chaser : Ship
{
    [SerializeField] float damage = 60f;
    
    override protected void Start()
    {
        base.Start();
        target = GameManager.manager.Player.transform;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!dead)
            Follow();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            GameObject temp=Instantiate(explosion, Vector3.Lerp(transform.position,collision.transform.position,0.5f),Quaternion.identity);
            temp.transform.localScale = new(2, 2,2);
            ToScore();
            Destroy(transform.parent.gameObject);
        }

    }
}
