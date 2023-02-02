using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Global Variable", menuName = "Global Variable")]
public class GlobalVar : ScriptableObject
{
    public new string name;
    [Header("Base data")]
    public bool boolVal;
    public int intVal;
    public float floatVal;
    public string stringVal;
    [Header("Modifications")]
    public float add; // Additions to intVal and floatVal, calculated **BEFORE** multiplications
    public float multiply; // Multiplications to intVal and floatVal
    public int toggleCount; // Number of times the var is toggled
    

    public void Initialize(string name, GlobalVarType type, bool boolVal, int intVal, float floatVal, string stringVal)
    {
        this.name = name;
        this.type = type;
        this.boolVal = boolVal;
        this.intVal = intVal;
        this.floatVal = floatVal;
        this.stringVal = stringVal;
        // The following modifiers are kept at 0
        this.add = 0;
        this.multiply = 0;
        this.toggleCount = 0;
    }
}
