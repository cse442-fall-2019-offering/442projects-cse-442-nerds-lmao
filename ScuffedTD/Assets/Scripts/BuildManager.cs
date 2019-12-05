using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public Text moneyText;
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject HertzTurretPrefab;
    public GameObject HughesTurretPrefab;
    public GameObject RudraTurretPrefab;
    public GameObject AlphonceTurretPrefab;

    public TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public bool BuildTurretOn(Node node)
    {

        if (PlayerStats.Money < turretToBuild.cost)
        {
            return false;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position, Quaternion.identity);
        node.turret = turret;
        return true;
    }

    public bool GotMoney() {
        if (turretToBuild == null) {
            return false;
        }

        return HasMoney;

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

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

    public void DeselectNode() {

        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
