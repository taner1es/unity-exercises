using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    public int experience = 40;
    public int gold = 1000;

    public Quest quest;
    public DisplayPlayer displayPlayer;

    private void Start()
    {
        displayPlayer.UpdateInfos(health, experience, gold);
    }

    public void GoBattle()
    {
        if (health <= 0)
            return;

        health -= 1;
        experience += 2;
        gold += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                experience += quest.experienceReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }

        displayPlayer.UpdateInfos(health, experience, gold);

    }
}
