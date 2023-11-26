using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] protected SpriteShip skin;
    [SerializeField] protected float maxLife;
    [SerializeField] protected float velocity;
    [SerializeField] protected Slider lifeBar;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float timeDie;
    [SerializeField] protected float angularVelocity;
    [SerializeField] protected GameObject explosion;

    protected float life;
    protected SpriteRenderer spriteRend;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D capCollider;
    protected bool dead = false;
    protected Transform target;

    virtual protected void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        life = maxLife;
        capCollider = GetComponent<CapsuleCollider2D>();
    }

    virtual protected void FixedUpdate()
    {
        if (dead)
            rb.velocity = Vector2.zero;
    }

    protected void ChangeSprite()
    {
        if (life <= 0.66*maxLife && life>0.33*maxLife)
            spriteRend.sprite = skin.Life66;

        if (life <= 0.33*maxLife && life>0)
            spriteRend.sprite = skin.Life33;

        if (life <= 0)
        {
            spriteRend.sprite = skin.Life0;
            StartCoroutine(Die());
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        ChangeSprite();
        lifeBar.value = life/maxLife;
        print(life);
    }

    virtual protected void Follow()
    {
        rb.velocity = velocity * (target.position - transform.position).normalized;
        transform.up = rb.velocity.normalized;
    }

    virtual protected void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    virtual protected void ToScore()
    {
        if (gameObject != GameManager.manager.Player)
            GameManager.manager.RefreshScore();
    }

    IEnumerator Die()
    {
        capCollider.enabled = false;
        dead = true;
        Destroy(lifeBar.gameObject);
        ToScore();
        GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
        temp.transform.localScale = new(2f, 2f, 2f);
        yield return new WaitForSeconds(timeDie);
        Destroy(transform.parent.gameObject);
    }
}
