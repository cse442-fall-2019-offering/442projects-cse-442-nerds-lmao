using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake ()
    {
        instance = this;
    }

    public GameObject HertzTurretPrefab;
    public GameObject HughesTurretPrefab;
    public GameObject RudraTurretPrefab;
    public GameObject AlphonceTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;

    }

    public void SetTurretToBuild(GameObject turret) {
        turretToBuild = turret;
    }
}
