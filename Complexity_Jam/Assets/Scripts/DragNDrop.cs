using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragNDrop : MonoBehaviour
{
    bool clicked;
    LayerMask tileLayerMask;
    Vector3 startPos;
    [SerializeField] Organ myOrgan;
    [SerializeField] Tile currentTile;

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
        startPos = transform.position;
        if (myOrgan.IsPlaced)
        {
            myOrgan.Remove();
            GameManager.Instance.RemoveOrgan(myOrgan);
        }
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
            if (!collider.gameObject.GetComponent<Tile>().Occupied)
            {
                //Removes current tile if it has been placed
                if (currentTile != null)
                {
                    currentTile.SetOccupiedStatus(false);
                    currentTile = null;
                }

                //Places Organ if tile is not occupied
                currentTile = collider.gameObject.GetComponent<Tile>();
                currentTile.SetOccupiedStatus(true);

                transform.position = collider.transform.position;
                myOrgan.Place();
                GameManager.Instance.PlaceOrgan(myOrgan);
            }
            else
            {
                //Returns organ to start
                if (currentTile != null)
                {
                    //Places organ on the previous tile
                    myOrgan.Place();
                    GameManager.Instance.PlaceOrgan(myOrgan);
                }
                transform.position = startPos;
            }
        }
        else
        {
            //If organ is not placed on a tile

            //Removes from tile if it was previously placed
            if (currentTile != null)
            {
                currentTile.SetOccupiedStatus(false);
                currentTile = null;
            }

            Destroy(gameObject);
        }
    }

    public void SetCurrentTile(Tile newTile)
    {
        currentTile = newTile;
    }
}
