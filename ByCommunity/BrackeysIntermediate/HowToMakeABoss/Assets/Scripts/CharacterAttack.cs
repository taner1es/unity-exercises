using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField]
    internal GameObject bulletPrefab;
    [SerializeField]
    internal Transform bulletStartPosition;
    [SerializeField]
    internal float meleeAttackCooldownTime = 1f;
    [SerializeField]
    internal float rangeAttackCooldownTime = 1.5f;
    [SerializeField]
    internal Slider sliderRange;
    [SerializeField]
    internal Slider sliderMelee;

    internal bool meleeAttack { get; set; }
    internal bool rangeAttack { get; private set; }

    float meleeAttackTimer;
    float rangeAttackTimer;

    private void Start()
    {
        sliderMelee.maxValue = meleeAttackCooldownTime;
        sliderRange.maxValue = rangeAttackCooldownTime;
    }

    private void Update()
    {
        // melee attack cooldown timing
        if (meleeAttack && meleeAttackTimer > 0)
        {
            meleeAttackTimer -= Time.fixedDeltaTime;
            sliderMelee.value = meleeAttackTimer;
        }
        else
        {
            meleeAttack = false;
        }

        // range attack cooldown timing
        if (rangeAttack && rangeAttackTimer > 0)
        {
            rangeAttackTimer -= Time.fixedDeltaTime;
            sliderRange.value = rangeAttackTimer;
        }
        else
        {
            rangeAttack = false;
        }

        // input handling for melee attack
        if (Input.GetKeyDown(KeyCode.Z) & !meleeAttack)
        {
            meleeAttack = true;
            meleeAttackTimer = meleeAttackCooldownTime;
            sliderMelee.value = meleeAttackCooldownTime;
        }

        // input handling and instantiate bullet for range attack
        if (Input.GetKeyDown(KeyCode.X) & !rangeAttack)
        {
            rangeAttack = true;

            bool facingRight = GetComponent<CharacterController2D>().m_FacingRight;

            // Instantiate and rotate according to facing side
            GameObject bulletGO = Instantiate(bulletPrefab, bulletStartPosition.position, Quaternion.Euler(0f, 0f, facingRight ? 90 : -90));
            bulletGO.GetComponent<Bullet>().SetFacingRight(facingRight);

            rangeAttackTimer = rangeAttackCooldownTime;
            sliderRange.value = rangeAttackCooldownTime;
        }
    }
}
