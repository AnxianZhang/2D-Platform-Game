using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private uint nbCoins = 0;

    private Text showCoins;

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

    private void Start()
    {
        this.showCoins = GameObject.FindGameObjectWithTag("Coins").GetComponentInChildren<Text>();
    }

    public static Inventory getInventory()
    {
        return instance;
    }

    public void addCoins(uint amoutn)
    {
        this.nbCoins += amoutn;
        this.showCoins.text = nbCoins.ToString();
    }
}
