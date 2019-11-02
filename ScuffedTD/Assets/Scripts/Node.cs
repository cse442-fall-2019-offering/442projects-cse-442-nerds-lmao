using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color transparent;
    public Color invalidColor;

    [Header("Optional")]
    public GameObject turret;

    private bool occupied;
    private SpriteRenderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start()
    {
        occupied = false;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        buildManager = BuildManager.instance;

    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            return;
        }

        if (!buildManager.CanBuild && !occupied)
        {
            rend.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney && !occupied)
        {
            rend.color = invalidColor;
            return;
        }

        if (buildManager.BuildTurretOn(this))
        {
            occupied = true;
            startColor = transparent;
            hoverColor = transparent;
            rend.color = transparent;

        }

    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild && !occupied)
        {
            rend.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney && !occupied)
        {
            rend.color = invalidColor;
            return;
        }


        rend.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = startColor;
    }

}