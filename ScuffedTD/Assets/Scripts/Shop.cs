using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint hertzTurret;
    public TurretBlueprint hughesTurret;
    public TurretBlueprint rudraTurret;
    public TurretBlueprint alphonceTurret;

    public Text hertzCost;
    public Text hughesCost;
    public Text rudraCost;
    public Text alphonceCost;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        buildManager.moneyText.text = PlayerStats.Money.ToString();
        hertzCost.text = hertzTurret.cost.ToString();
        hughesCost.text = hughesTurret.cost.ToString();
        rudraCost.text = rudraTurret.cost.ToString();
        alphonceCost.text = alphonceTurret.cost.ToString();

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
