using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    public Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
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
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

    }

    void OnMouseEnter()
    {

        rend.material.color = hoverColor;
        Debug.Log(hoverColor);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        Debug.Log(startColor);
    }

}