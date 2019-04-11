using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCard : MonoBehaviour
{
    public Vector2 offset = Vector2.zero;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;

    }

    private void OnMouseUp()
    {
        if(isMoving)
        {
            isMoving = false;

            // code here to do stuff with card depending on what it was dragged over
        }
    }
}
