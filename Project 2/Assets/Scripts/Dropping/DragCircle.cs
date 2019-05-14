using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCircle : MonoBehaviour
{
    public bool DraggingItem = false;
    public GameObject draggedObject;
    //public List<Transform> targetLocs;

    void Update()
    {
        if (HasInput)
        {
            //Debug.Log("clicked");
            DragOrPickup();
        }
        else
        {
            if (DraggingItem)
            {
                DropItem();
            }
        }
        if(Gamemanager.manager.handTime <= 0)
        {
            DraggingItem = false;
        }
    }

    private void DragOrPickup()
    {
        var inputPosition = CurrentTouchPosition;

        if (DraggingItem)
        {
            draggedObject.transform.position = inputPosition;
        }
        else
        {
            // Layer mask to only allow draggable objects to be dragged
            LayerMask mask = LayerMask.GetMask("Draggable");

            // raycast straight down from mouse and see what we hit
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f, mask);
            // raycast2dhit returns an array of objects below the mouse
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    DraggingItem = true;
                    draggedObject = hit.transform.gameObject;
                }
            }
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private bool HasInput
    {
        get
        {
            return Input.GetMouseButton(0);
        }
    }

    private void DropItem()
    {
        DraggingItem = false;

        //var distance = Vector2.Distance(draggedObject.transform.position, targetLocs[0].position);
        //var target = targetLocs[0];

        //foreach (Transform t in targetLocs)
        //{
        //    if (Vector2.Distance(draggedObject.transform.position, t.position) < distance)
        //    {
        //        target = t;
        //        distance = Vector2.Distance(draggedObject.transform.position, t.position);
        //    }
        //}

        //if (distance < 1)
        //{
        //    Vector2 matchedPosition = target.position;
        //    draggedObject.transform.position = matchedPosition;
        //}
    }
}
