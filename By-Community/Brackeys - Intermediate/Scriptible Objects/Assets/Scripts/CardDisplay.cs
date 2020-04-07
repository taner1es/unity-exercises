using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text no;
    public Text name;

    public RawImage avatarImage;

    public Text fire;
    public Text earth;
    public Text aqua;

    public Text description;

    private void Start()
    {
        no.text = card.no.ToString();
        name.text = card.name;

        avatarImage.texture = card.avatar.texture;

        fire.text = card.fire.ToString();
        earth.text = card.earth.ToString();
        aqua.text = card.aqua.ToString();

        description.text = card.description;
    }
}
