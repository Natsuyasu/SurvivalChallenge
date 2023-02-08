﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] DataCotainer DataCotainer;
    TMPro.TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Update()
    {

        text.text = "Coins:"+ DataCotainer.coins.ToString();
    }

}