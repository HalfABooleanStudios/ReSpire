using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Currency", menuName = "Currency")]
public class Currency : ScriptableObject
{
    public Sprite icon;
    public new string name;
    public string description;

    public void Initialize(Sprite icon, string name, string description)
    {
        this.icon = icon;
        this.name = name;
        this.description = description;
    }
}