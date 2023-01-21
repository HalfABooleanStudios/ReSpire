using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Tech", menuName = "Tech")]
public class Tech : ScriptableObject
{
    public Sprite icon;
    public new string name;
    public string description;
    public int cost;
    public bool autoUnlock;
    public bool unlocked;
    public bool isRootTech;
    public List<Tech> parentTechs;

    public void Initialize(Sprite icon, string name, string description, int cost, bool isRootTech, List<Tech> parentTechs)
    {
        this.icon = icon;
        this.name = name;
        this.description = description;
        this.cost = cost;
        this.isRootTech = isRootTech;
        this.parentTechs = parentTechs;
    }
}
