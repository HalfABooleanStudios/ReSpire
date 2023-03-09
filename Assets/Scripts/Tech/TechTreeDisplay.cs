using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechTreeDisplay : MonoBehaviour
{
    public GameObject techPrefab;

    private Dictionary<Tech, GameObject> techBoxes = new Dictionary<Tech, GameObject>();

    private void Update()
    {
        List<Tech> unlocked = TechManager.Instance.unlocked;
        List<Tech> visible = TechManager.Instance.unlocked;
        foreach (Tech tech in unlocked)
        {
            if (!techBoxes.ContainsKey(tech))
            {
                GameObject obj = Instantiate(techPrefab, transform);
                AdjustPosition(obj);
                techBoxes.Add(tech, obj);
            }
        }
    }

    private void AdjustPosition(GameObject obj)
    {
        RectTransform rt = obj.GetComponent<RectTransform>();
        int offset = 150 + 250*techBoxes.Count;
        int x = offset%1900;
        int y = -150 - 250*(int) Math.Floor((float) offset/1900);
        rt.anchoredPosition = new Vector2(x,y);
    }
}
