using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float rageAt;
    public UnityEngine.UI.Slider sliderHP;

    internal bool isVulnerable = true;

    private void Start()
    {
        sliderHP.maxValue = maxHealth;
        sliderHP.value = health;
    }

    internal void TakeDamage(float damage)
    {
        if (!isVulnerable)
            return;

        health -= damage;

        if (health < 0)
            health = 0;

        if (health <= rageAt)
            GetComponent<Animator>().SetBool("Enrage", true);

        sliderHP.value = health;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
