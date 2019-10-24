using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint hertzTurret;
    public TurretBlueprint hughesTurret;
    public TurretBlueprint rudraTurret;
    public TurretBlueprint alphonceTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        buildManager.moneyText.text = PlayerStats.Money.ToString();
    }

    public void SelectHertzTurret()
    {
        buildManager.SelectTurretToBuild(hertzTurret);

    }

    public void SelectHughesTurret()
    {
        buildManager.SelectTurretToBuild(hughesTurret);

    }

    public void SelectRudraTurret()
    {
        buildManager.SelectTurretToBuild(rudraTurret);

    }

    public void SelectAlphonceTurret()
    {
        buildManager.SelectTurretToBuild(alphonceTurret);

    }
}
