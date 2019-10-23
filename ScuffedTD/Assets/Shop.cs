using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseHertzTurret()
    {
        buildManager.SetTurretToBuild(buildManager.HertzTurretPrefab);

    }

    public void PurchaseHughesTurret()
    {
        buildManager.SetTurretToBuild(buildManager.HughesTurretPrefab);

    }

    public void PurchaseRudraTurret()
    {
        buildManager.SetTurretToBuild(buildManager.RudraTurretPrefab);

    }

    public void PurchaseAlphonceTurret()
    {
        buildManager.SetTurretToBuild(buildManager.AlphonceTurretPrefab);

    }
}
