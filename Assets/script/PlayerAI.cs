using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    GameManger gameManger;
    private Rigidbody2D myRB;
    EnemyChaseScript enemyChase;
    //Animator myAnim;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator myAnim;
    private EnemyHealth enemyHealth;
 
    private void Awake()
    {
        //myAnim = GetComponent<Animator>();
        //myRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("Player");
        gameManger = gameController.GetComponent<GameManger>();
        //myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        enemyChase = GetComponent<EnemyChaseScript>();

    }

    void Update()
    {
        transform.Translate(gameManger.moveVector * gameManger.speed * Time.deltaTime);
        myAnim.SetBool("walk", true);
        if(EnemyInSight())
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                myAnim.SetTrigger("attack");
            }
        }
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            enemyHealth = hit.transform.GetComponent<EnemyHealth>();

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
            enemyHealth.addDamage(damage);
        }
    }

    // public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 KnockbackDir){

    //      float timer = 0;

    //      while(knockDur > timer)
    //      {
    //          timer += Time.deltaTime;
    //          myRB.AddForce(new Vector3(KnockbackDir.x * -100, KnockbackDir.y * knockbackPwr, transform.position.z));
    //      }

    //      yield return 0;
    //   }
    
    public void OnHit()
    {   
         Vector2 knockbackForce = new Vector2(-100f, 1f);
         enemyChase.AddKnockbackForce(knockbackForce);
    }
}
