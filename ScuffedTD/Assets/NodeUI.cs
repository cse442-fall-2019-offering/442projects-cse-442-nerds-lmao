using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    public Text sellAmount;
    public Canvas canvas;
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        canvas.GetComponent<RectTransform>().position = target.GetBuildPosition();
        Vector3 offset = new Vector3(0.0f, 3.0f, 0.0f);
        canvas.GetComponent<RectTransform>().position += offset;

        //sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }


    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
