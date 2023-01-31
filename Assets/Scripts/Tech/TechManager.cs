using UnityEngine;
using System.Collections.Generic;

public class TechManager : MonoBehaviour
{
    private static TechManager instance;

    /* This ensures that there is always exactly one instance of the TechManager class
     * Furthermore, the TechManager class can be refernece from anywhere using TechManager.Instance
     */
    public static TechManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<TechManager>();
                if (!instance)
                {
                    GameObject obj = new GameObject("Tech Manager");
                    instance = obj.AddComponent<TechManager>();
                }
            }
            return instance;
        }
    }

    public List<Tech> unlocked; // List of unlocked Techs
    public List<Tech> visible; // List of visible, but locked, Techs
    public List<Tech> hidden; // List of hidden Techs

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
            ReadTechs();
        }
    }

    private void ReadTechs()
    {
        unlocked.Clear();
        visible.Clear();
        hidden.Clear();
        // Read all Tech files in the folder "Resources/Techs"
        List<Tech> allTechs = new List<Tech>(Resources.LoadAll<Tech>(GameManager.Instance.isDebug ? "TechsDEBUG" : "Techs"));
        foreach (Tech tech in allTechs)
        {
            if (tech.status == Tech.TechStatus.UNLOCKED)
            {
                unlocked.Add(tech);
            }
            else if (tech.status == Tech.TechStatus.VISIBLE)
            {
                visible.Add(tech);
            }
            else
            {
                hidden.Add(tech);
            }
        }
    }

    public void UnlockTech(string techName)
    {
        Tech tech = new Tech();
        foreach (Tech visibleTech in visible)
        {
            if (string.Equals(visibleTech.name, techName))
            {
                tech = visibleTech;
                break;
            }
        }
        UnlockTech(tech);
    }

    public void UnlockTech(Tech tech)
    {
        tech.status = Tech.TechStatus.UNLOCKED;
        foreach (Tech child in tech.children)
        {
            if (child.canAutoUnlock)
            {
                UnlockTech(child);
            }
            else
            {
                child.status = Tech.TechStatus.VISIBLE;
            }
        }
        ReadTechs();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnlockTech("Artificial Intelligence");
        }
    }
}