using UnityEngine;

public class Static_Enemy : MonoBehaviour
{
    [SerializeField] float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
