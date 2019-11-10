using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public Color hoverColor;
    public Color transparent;
    public Color invalidColor;

    [Header("Optional")]
    public GameObject turret;

    private bool occupied;
    private Image img;
    private Color startColor;
    private bool pressed = false;

    BuildManager buildManager;


    void Start()
    {
        occupied = false;
        img = GetComponent<Image>();
        startColor = img.color;
        buildManager = BuildManager.instance;

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (turret != null)
        {
            return;
        }

        if (!buildManager.CanBuild && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        if (buildManager.BuildTurretOn(this))
        {
            occupied = true;
            startColor = transparent;
            hoverColor = transparent;
            img.color = transparent;

        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pressed = true;
        if (!buildManager.CanBuild && !occupied)
        {
            img.color = invalidColor;
            return;
        }

        if (!buildManager.HasMoney && !occupied)
        {
            img.color = invalidColor;
            return;
        }


        img.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pressed = false;
        img.color = startColor;
    }

}