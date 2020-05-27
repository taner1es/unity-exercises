using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Vector2 attackOffset;
    public float attackRange;
    public LayerMask attackMask;
    public float attackDamage = 10;
    public float attackDamageEnrageMultiplier = 2f;

    internal void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * (GetComponent<Boss>().isFlipped ? 1 : -1);
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            if(GetComponent<Animator>().GetBool("Enrage"))
                colInfo.GetComponent<CharacterHealth>().TakeDamage(attackDamage * attackDamageEnrageMultiplier);
            else
                colInfo.GetComponent<CharacterHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (GetComponent<Animator>().GetBool("Enrage"))
            Gizmos.color = new Color(255, 0, 0, 1);
        else
            Gizmos.color = new Color(0, 255, 0, 1);

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * (GetComponent<Boss>().isFlipped ? 1 : -1);
        pos += transform.up * attackOffset.y;

        Gizmos.DrawSphere(pos, attackRange);
    }
}
