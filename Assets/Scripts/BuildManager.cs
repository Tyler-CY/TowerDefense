using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    // All available build options
    //public GameObject standardTurretPrefab;
    //public GameObject missileTurretPrefab;
    //public GameObject laserTurretPrefab;



    public static BuildManager instance;
    // Handle Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    
    // The turret we want to build
    private TurretBlueprint turretToBuild;

    // selected Node
    private Node selectedNode;

    public NodeUI nodeUI;

    // Properties
    // Return whether we can build (on the node)
    public bool CanBuild
    {
        get 
        { 
            return turretToBuild != null; 
        }
    }
    // Return whether we have enough money to build
    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
