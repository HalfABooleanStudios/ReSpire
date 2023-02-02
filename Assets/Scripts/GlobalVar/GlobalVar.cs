using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Global Variable", menuName = "Global Variable")]
public class GlobalVar : ScriptableObject
{
    public enum GlobalVarType
    {
        BOOL,
        INT,
        FLOAT,
        STRING
    }
    public new string name;
    public GlobalVarType type;
    public bool boolVal;
    public int intVal;
    public float floatVal;
    public string stringVal;

    public void Initialize(string name, GlobalVarType type, bool boolVal, int intVal, float floatVal, string stringVal)
    {
        this.name = name;
        this.type = type;
        this.boolVal = boolVal;
        this.intVal = intVal;
        this.floatVal = floatVal;
        this.stringVal = stringVal;
    }
}
