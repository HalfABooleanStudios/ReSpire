using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GlobalVarModifier
{
    public string globalVarName;
    public float add;
    public float multiply;
    public bool toggle;

    public CurrencyCost(string globalVarName, float add, float multiply, bool toggle)
    {
        this.globalVarName = globalVarName;
        this.add = add;
        this.multiply = multiply;
        this.toggle = toggle;
    }
}