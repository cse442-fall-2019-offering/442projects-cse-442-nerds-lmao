using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color transparent;
    public Color invalidColor;

    private GameObject turret;

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
            Debug.Log("Can't build there");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();

        if (turretToBuild == null)
        {
            rend.color = invalidColor;
        }

        else {
            startColor = transparent;
            hoverColor = transparent;
            rend.color = transparent;

        }

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);


    }

    void OnMouseEnter()
    {
        rend.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = startColor;
    }

}