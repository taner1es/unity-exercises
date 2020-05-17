using System;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;

    public QuestGoal goal;

    internal void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed!");
    }
}
