using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float velocity;
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime=5f;
    [SerializeField] GameObject explosion;
    [SerializeField] string tagName;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.rotation * Vector2.up).normalized*velocity;
        Invoke(nameof(Explode), lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            collision.gameObject.GetComponent<Ship>().TakeDamage(damage);
            Explode();
        }

        if (collision.gameObject.CompareTag("Island"))
         
            Explode();
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
