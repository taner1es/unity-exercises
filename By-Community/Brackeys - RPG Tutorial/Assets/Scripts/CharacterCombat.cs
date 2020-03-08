﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCoolDown <= 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCoolDown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
