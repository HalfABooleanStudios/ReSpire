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

    public List<Tech> unlocked = new List<Tech>();
    public List<Tech> locked = new List<Tech>();

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
            // This reads all ScriptableObjects in the folder Resources/Techs and sorts them into locked and unlocked
            List<Tech> availableTechs = new List<Tech>(Resources.LoadAll<Tech>("Techs")); 
            foreach (Tech availableTech in availableTechs)
            {
                if (availableTech.unlocked)
                {
                    unlocked.Add(availableTech);
                }
                else
                {
                    locked.Add(availableTech);
                }
            }
        }
    }

    public void UnlockTech(Tech tech)
    {
        locked.Remove(tech);
        unlocked.Add(tech);
    }

    public void LockTech(Tech tech)
    {
        unlocked.Remove(tech);
        locked.Add(tech);
    }
}