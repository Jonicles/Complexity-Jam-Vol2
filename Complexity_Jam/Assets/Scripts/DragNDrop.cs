using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragNDrop : MonoBehaviour
{
    bool clicked;
    LayerMask tileLayerMask;

    private void Start()
    {
        tileLayerMask = LayerMask.GetMask("Tile");
    }
    private void FixedUpdate()
    {
        if (clicked)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnMouseDown()
    {
        clicked = true;
        GameManager.Instance.DisplayTiles();
    }

    private void OnMouseUp()
    {
        clicked = false;
        //Sets dragged objects position to the tiles position
        SnapToTile();

        GameManager.Instance.DisplayTiles(false);
    }

    private void SnapToTile()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, GetComponent<BoxCollider2D>().size, 0, tileLayerMask);
        if (collider != null)
        {
            transform.position = collider.transform.position;
        }
    }
}
