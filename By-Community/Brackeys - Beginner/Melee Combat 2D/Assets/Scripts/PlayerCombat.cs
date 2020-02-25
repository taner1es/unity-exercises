using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;
    
    Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 30;

    float attackRate = 2f;
    float nextAttackTime;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        attackPoint = transform.Find("AttackPoint").GetComponent<Transform>();
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
    }

    private void Attack()
    {
        // Play attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
