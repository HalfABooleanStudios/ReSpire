using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Tech", menuName = "Tech")]
public class Tech : ScriptableObject
{
    public enum TechStatus
    {
        HIDDEN,
        VISIBLE,
        UNLOCKED
    }

    [Header("Info")]
    public Sprite icon;
    public new string name;
    public string description;
    public List<GlobalVarModifier> modifiers;
    [Header("Unlock")]
    public TechStatus status;
    public bool canAutoUnlock;
    public List<CurrencyCost> cost;
    [Header("Data")]
    public bool isRootTech;
    public List<Tech> children;
    public List<Tech> techRequirements;

    public void Initialize(
        Sprite icon, string name, string description, List<GlobalVarModifier> modifiers,
        List<CurrencyCost> cost, bool canAutoUnlock, TechStatus status,
        bool isRootTech, List<Tech> children, List<Tech> techRequirements)
    {
        this.icon = icon;
        this.name = name;
        this.description = description;
        this.modifiers = modifiers;
        this.cost = cost;
        this.canAutoUnlock = canAutoUnlock;
        this.status = status;
        this.isRootTech = isRootTech;
        this.children = children;
        this.techRequirements = techRequirements;
    }
}
