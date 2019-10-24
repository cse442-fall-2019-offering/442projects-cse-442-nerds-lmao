﻿using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public Text moneyText;
    public static BuildManager instance;

    void Awake ()
    {
        instance = this;
    }

    public GameObject HertzTurretPrefab;
    public GameObject HughesTurretPrefab;
    public GameObject RudraTurretPrefab;
    public GameObject AlphonceTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node) {

        if (PlayerStats.Money < turretToBuild.cost) {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        moneyText.text = PlayerStats.Money.ToString();



        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.transform.position, Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }
}