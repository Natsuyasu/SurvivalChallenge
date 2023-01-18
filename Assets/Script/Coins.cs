﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataCotainer data;
    //public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    public void Add(int count)
    {
        data.coins += count;
        coinsCountText.text = "Coins: " + data.coins.ToString();
    }

}
