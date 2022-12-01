using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator myanim;
    //private EnemyHealth enemyHealth;
    private EnemyBehaviour enemyBehaviour;

    private void Awake()
    {
        myanim = GetComponent<Animator>();
    }

    void Update()
    {
        if (EnemyInSight())
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                myanim.SetTrigger("attack");
            }
        }
    }
    
    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            enemyBehaviour = hit.transform.GetComponent<EnemyBehaviour>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
        if (EnemyInSight())
        {
            enemyBehaviour.TakeHit(damage);
        }
    }
}
