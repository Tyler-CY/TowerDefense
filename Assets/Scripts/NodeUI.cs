using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject ui;
    public Vector3 offset;

    public Text upgradeCostText;
    public Button upgradeButton;

    public Text sellText;
    public Button sellButton;

    public void SetTarget(Node target)
    {

        this.target = target;

        
        transform.position = target.GetBuildPosition() + offset;

        if (!target.isUpgraded)
        {
            upgradeCostText.text = "<b>UPGRADE</b> \n$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true;

            sellText.text = "<b>SELL</b>\n$" + target.turretBlueprint.GetSellAmount();
        }
        else
        {
            upgradeCostText.text = "<b>MAXED\nOUT</b>";
            upgradeButton.interactable = false;

            sellText.text = "<b>SELL</b>\n$" + (target.turretBlueprint.GetSellAmount() + target.turretBlueprint.upgradeCost);
        }

                

        ui.SetActive(true);
    }

    private void Update()
    {

    }
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
