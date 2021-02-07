using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicker : MonoBehaviour
{
    public Camera cam;
    private Ray2D ray;
    private RaycastHit2D hit;
    private GameObject selectedTile;

    private void Update()
    {
        RaycastSelecting();
        if (selectedTile != null)
        {
            MouseAction();
        }
    }

    private void RaycastSelecting()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, cam.transform.position - mousePosition , 0,001);
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
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
