using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CurrencyCost
{
    public Currency currency;
    public int cost;

    public CurrencyCost(Currency currency, int cost)
    {
        this.currency = currency;
        this.cost = cost;
    }
}