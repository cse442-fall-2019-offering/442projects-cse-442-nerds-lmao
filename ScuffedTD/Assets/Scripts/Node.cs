using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public Color hoverColor;
    public Color transparent;
    public Color invalidColor;

    private Color savedHoverColor;
    private Color savedStartColor;
    private Color savedInvalidColor;



    [Header("Optional")]
    public GameObject turret;

    public TurretBlueprint turretBlueprint;

    private bool occupied;
    private Image img;
    private Color startColor;

    BuildManager buildManager;



    void Start()
    {
        savedHoverColor = new Color(0.08235f, 1f, 0f, 0.49019f);
        savedStartColor = new Color(0.08235f, 1f, 0f, 0.2941176f);
        savedInvalidColor = new Color(1f, 0f, 0f, 0.2941176f);
        occupied = false;
        img = GetComponent<Image>();
        startColor = img.color;
        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition()
    {
        Debug.Log(GetComponent<RectTransform>().position);
        return GetComponent<RectTransform>().position;
    }

    public void SellTurret ()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        occupied = false;
        Destroy(turret);
        img.color = savedStartColor;
        startColor = savedStartColor;
        hoverColor = savedHoverColor;
        invalidColor = savedInvalidColor;

        turretBlueprint = null;

    }


    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        occupied = true;
        startColor = transparent;
        hoverColor = transparent;
        img.color = transparent;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        if (!buildManager.GotMoney() && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!buildManager.CanBuild && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        if (!buildManager.GotMoney() && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        img.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = startColor;
    }

}