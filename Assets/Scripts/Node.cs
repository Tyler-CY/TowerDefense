using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color noMoneyColor;

    // turret offset 
    public Vector3 offset;

    // turret on the node
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("OUT OF RESOURCES");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        turretBlueprint = blueprint;

        
        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("NOT ENOUGH MONEY TO UPGRADE");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Remove old turret
        Destroy(this.turret);

        // Build a new turret
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        isUpgraded = true;

        Debug.Log("Turret Upgraded! Money left: " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        if (!isUpgraded)
        {
            PlayerStats.Money += turretBlueprint.GetSellAmount();
        }
        else
        {
            PlayerStats.Money += turretBlueprint.GetSellAmount() + turretBlueprint.upgradeCost;
        }
        

        // Insert Effect
        Debug.Log("Sell Turret Effect");

        Destroy(turret);
        isUpgraded = false;
        turretBlueprint = null;
    }

    void OnMouseDown()
    {


        // Prevent clicking through the UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        { 
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }


    void OnMouseEnter()
    {
        // Prevent clicking through the UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // if can't build, don't change color
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
