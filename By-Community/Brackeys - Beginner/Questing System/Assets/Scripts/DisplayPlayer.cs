using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    public Text healthText;
    public Text experienceText;
    public Text goldText;

    internal void UpdateInfos(int newHealth, int newExperience, int newGold)
    {
        healthText.text = newHealth.ToString();
        experienceText.text = newExperience.ToString();
        goldText.text = newGold.ToString();
    }
}
