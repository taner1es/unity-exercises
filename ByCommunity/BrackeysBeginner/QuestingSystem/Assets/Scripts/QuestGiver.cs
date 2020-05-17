using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text experienceRewardText;
    public Text goldRewardText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceRewardText.text = quest.experienceReward.ToString();
        goldRewardText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;

        player.quest = quest;
    }
}
