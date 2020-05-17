using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 0)]
public class Card : ScriptableObject
{
    public int no;

    public new string name;
    
    public Sprite avatar;

    public int fire;
    public int earth;
    public int aqua;

    public string description;

    public void PrintCard()
    {
        Debug.Log(
                "No: " + no +
                "Name: " + name +
                "Avatar: " + avatar.texture.name + "." + avatar.texture.format +
                "Fire: " + fire +
                "Earth: " + earth +
                "Aqua: " + aqua
                );
    }
}
