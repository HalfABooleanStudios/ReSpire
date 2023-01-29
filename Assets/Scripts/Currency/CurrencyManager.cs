using UnityEngine;
using System.Collections.Generic;

public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;

    /* This ensures that there is always exactly one instance of the CurrencyManager class
     * Furthermore, the CurrencyManager class can be refernece from anywhere using CurrencyManager.Instance
     */
    public static CurrencyManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<CurrencyManager>();
                if (!instance)
                {
                    GameObject obj = new GameObject("Currency Manager");
                    instance = obj.AddComponent<CurrencyManager>();
                }
            }
            return instance;
        }
    }

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
        }
    }
}