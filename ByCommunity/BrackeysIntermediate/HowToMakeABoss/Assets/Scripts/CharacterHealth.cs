using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    float health = 100;

    internal void TakeDamage(float damage)
    {

        health -= damage;

        if (health < 0)
            health = 0;

        GetComponent<Animator>().SetTrigger("hit");
    }
}
