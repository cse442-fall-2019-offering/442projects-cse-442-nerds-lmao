using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color transparent;
    public Color invalidColor;

    [Header("Optional")]
    public GameObject turret;

    private SpriteRenderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start()
    {
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

        if (!buildManager.CanBuild) {
            rend.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney)
        {
            rend.color = invalidColor;
            return;
        }

        buildManager.BuildTurretOn(this);

        startColor = transparent;
        hoverColor = transparent;
        rend.color = transparent;

    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            rend.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney)
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