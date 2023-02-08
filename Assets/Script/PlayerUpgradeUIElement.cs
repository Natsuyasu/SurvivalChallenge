using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgradeUIElement : MonoBehaviour
{
    [SerializeField] PlayerPersistantUpgrade upgrade;
    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI Price;

    [SerializeField] DataCotainer dataCotainer;

    private void Start()
    {
        UpdateElement();
    }


    public void Upgrade()
    {
        PlayerUpgrades playerUpgrades = dataCotainer.upgrades[(int)upgrade];

        if(playerUpgrades.level >= playerUpgrades.max_level)
        {
            return;
        }


        if(dataCotainer.coins >= playerUpgrades.CostToUpgrade)
        {
            dataCotainer.coins -= playerUpgrades.CostToUpgrade;
            playerUpgrades.level += 1;
            UpdateElement();
        }
    }

    void UpdateElement()
    {
        PlayerUpgrades playerUpgrades = dataCotainer.upgrades[(int)upgrade];
        upgradeName.text = upgrade.ToString();
        Level.text = playerUpgrades.level.ToString();
        Price.text = playerUpgrades.CostToUpgrade.ToString();
;    }

}
