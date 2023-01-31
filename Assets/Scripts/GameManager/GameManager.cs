using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
                if (!instance)
                {
                    GameObject obj = new GameObject("Game Manager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public bool isDebug = true;
}
