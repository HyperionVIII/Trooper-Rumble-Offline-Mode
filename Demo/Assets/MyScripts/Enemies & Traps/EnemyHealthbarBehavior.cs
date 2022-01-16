using UnityEngine;

public class EnemyHealthbarBehavior : MonoBehaviour
{
    public float hitpoints;
    public float maxHitpoints = 5;
    public HealthbarBehavior healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitpoints;
        healthbar.setHealth(hitpoints, maxHitpoints);
    }

    public void takeHit(float damage) {
        hitpoints -= damage;
        healthbar.setHealth(hitpoints, maxHitpoints);

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }

    }
}
