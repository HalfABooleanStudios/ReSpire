using UnityEngine;
using System.Collections.Generic;

public class GlobalVarManager : MonoBehaviour
{
    private static GlobalVarManager instance;

    /* This ensures that there is always exactly one instance of the GlobalVarManager class
     * Furthermore, the GlobalVarManager class can be refernece from anywhere using GlobalVarManager.Instance
     */
    public static GlobalVarManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GlobalVarManager>();
                if (!instance)
                {
                    GameObject obj = new GameObject("GlobalVar Manager");
                    instance = obj.AddComponent<GlobalVarManager>();
                }
            }
            return instance;
        }
    }

    public List<GlobalVar> globalVars = new List<GlobalVar>();

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ReadGlobalVars();
        }
    }


    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>DEBUG
    private List<GlobalVar> HotSaveGlobalVars(List<GlobalVar> original)
    {
        List<GlobalVar> hotSave = new List<GlobalVar>();
        // Create instances (copies)
        foreach (GlobalVar globalVar in original)
        {
            hotSave.Add(Instantiate(globalVar));
        }
        return hotSave;
    }
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<END DEBUG

    private void ReadGlobalVars()
    {
        globalVars.Clear();
        // Read all GlobalVar files in the folder "Resources/GlobalVars"
        globalVars = new List<GlobalVar>(Resources.LoadAll<GlobalVar>("GlobalVars"));
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>DEBUG
        if (GameManager.Instance.isDebug) {
            globalVars = HotSaveGlobalVars(globalVars);
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<END DEBUG
    }

    public void Modify(GlobalVarModifier modifier)
    {
        GlobalVar targetGlobalVar = null;
        // Find the GlobalVar
        foreach (GlobalVar globalVar in globalVars)
        {
            if (string.Equals(globalVar.name, modifier.globalVarName))
            {
                targetGlobalVar = globalVar;
                break;
            }
        }
        // Apply the modifier
        targetGlobalVar.add += modifier.add;
        targetGlobalVar.multiply *= modifier.multiply;
        if (modifier.toggle) { targetGlobalVar.toggleCount += 1; }
    }

    public GlobalVar Get(string globalVarName)
    {
        GlobalVar targetGlobalVar = null;
        // Find the GlobalVar
        foreach (GlobalVar globalVar in globalVars)
        {
            if (string.Equals(globalVar.name, globalVarName))
            {
                targetGlobalVar = globalVar;
                break;
            }
        }
        return targetGlobalVar;
    }

    public bool GetBoolVal(string globalVarName)
    {
        GlobalVar globalVar = Get(globalVarName);
        if (globalVar.toggleCount % 2 == 0)
        {
            // If number of toggles is even, bool remains at original state
            return globalVar.boolVal;
        }
        else
        {
            // If number of toggles is odd, bool changes state
            return !globalVar.boolVal;
        }
    }

    public int GetIntVal(string globalVarName)
    {
        GlobalVar globalVar = Get(globalVarName);
        return (int) ((globalVar.intVal + globalVar.add) * globalVar.multiply);
    }

    public float GetFloatVal(string globalVarName)
    {
        GlobalVar globalVar = Get(globalVarName);
        return (globalVar.floatVal + globalVar.add) * globalVar.multiply;
    }

     public string GetStringVal(string globalVarName)
    {
        return Get(globalVarName).stringVal;
    }
}