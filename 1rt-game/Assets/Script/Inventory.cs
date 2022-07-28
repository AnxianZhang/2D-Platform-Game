using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public uint nbCoins = 0;

    public Text showCoins;

    private static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an invetory");
            return;
        }
        instance = this;
    }

    public static Inventory getInventory()
    {
        return instance;
    }

    public void addCoins(uint amoutn)
    {
        this.nbCoins += amoutn;
        showCoins.text = nbCoins.ToString();
    }
}
