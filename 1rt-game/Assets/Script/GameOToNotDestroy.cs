using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOToNotDestroy : MonoBehaviour
{
    public GameObject [] toNotDestroy;
    private void Awake()
    {
        foreach (var gO in toNotDestroy)
            DontDestroyOnLoad(gO);
    }
}
