using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicker : MonoBehaviour
{
    public Camera cam;
    public Transform mouseFollow;
    public PositionSpawner positionSpawner;
    private Vector3 dragIconDefaultLocation = new Vector3(0, 0, 0);
    private Ray2D ray;
    private RaycastHit2D hit;
    private GameObject selectedTile;
    private GameObject selectedObject;
    private GameObject currentObjectIcon;
    private Vector3 worldSpaceMousePosition;
    private bool hasObjectSelected;
    private bool defensiveObjectSelected;
    private bool offensiceObjectSelected;
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        Debug.Log(gm);
    }

    private void Update()
    {

        RaycastSelecting();
        if (hasObjectSelected == true)
        {
            MouseAction();
        }
    }

    private void RaycastSelecting()
    {
        worldSpaceMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(worldSpaceMousePosition, cam.transform.position - worldSpaceMousePosition , 0,001);
        if (hit == true && selectedTile == null)
        {
            selectedTile = hit.transform.gameObject;
            selectedTile.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if(hit == true && hit.transform.gameObject != selectedTile && selectedTile != null)
        {
            selectedTile.GetComponent<SpriteRenderer>().enabled = false;
            selectedTile = null;
            selectedTile = hit.transform.gameObject;
            selectedTile.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (hit == false && selectedTile != null)
        {
            selectedTile.GetComponent<SpriteRenderer>().enabled = false;
            selectedTile = null;
        }
        else if (hit == false)
        {
            selectedTile = null;
        }
    }

    private void MouseAction()
    {
        mouseFollow.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }
    }

    public void PickObject(GameObject objectToBuild)
    {
        BaseUnit objectToBuildUnit = objectToBuild.GetComponent<BaseUnit>();
        if (objectToBuildUnit.GetCost() <= gm.currency)
        {
            selectedObject = objectToBuild;
            GameManager.instance.currency -= objectToBuildUnit.GetCost();

            if (objectToBuildUnit.GetUnitType() is BaseUnit.UnitType.Offensive)
            {
                offensiceObjectSelected = true;
            }
            else if (objectToBuildUnit.GetUnitType() is BaseUnit.UnitType.Defensive)
            {
                defensiveObjectSelected = true;
            }
            hasObjectSelected = true;
        }
        else
        {

        }
    }

    public void PickObjectIcon(GameObject givenIcon)
    {
        currentObjectIcon = givenIcon;
        currentObjectIcon.SetActive(true);
        currentObjectIcon.transform.SetParent(mouseFollow);
        currentObjectIcon.transform.localPosition = dragIconDefaultLocation;
    }

    public void PlaceObject()
    {
        BaseUnit objectToBuildUnit = selectedObject.GetComponent<BaseUnit>();
        positionSpawner.SpawnAndPositionObject(selectedObject);
        ResetSelection(selectedObject, currentObjectIcon);
    }

    public void PickObjectCancel()
    {
        BaseUnit objectToBuildUnit = selectedObject.GetComponent<BaseUnit>();
        GameManager.instance.currency += objectToBuildUnit.GetCost();
        ResetSelection(selectedObject, currentObjectIcon);
    }

    private void ResetSelection(GameObject objectToBuild, GameObject objectIcon)
    {
        objectIcon.SetActive(false);
        objectIcon.transform.SetParent(null);
        objectIcon.transform.position = dragIconDefaultLocation;

        mouseFollow.position = dragIconDefaultLocation;

        offensiceObjectSelected = false;
        defensiveObjectSelected = false;

        selectedObject = null;
        currentObjectIcon = null;

        hasObjectSelected = false;
    }
}
