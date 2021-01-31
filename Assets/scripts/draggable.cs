using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    private bool isDragging = false;
    private List<string> overlapping = new List<string>();

    void Update()
    {
        if (isDragging) {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepos);
        }
    }

    public void OnMouseDown() {
        isDragging = true;
        Debug.Log("dragging object");
    }

    public void OnMouseUp() {
        Debug.Log("letting go");
        isDragging = false;


        if(overlapping.Count == 1) {
            Debug.Log("overlapping one " + overlapping[0]);
            
            // Determine if we are colliding with a box or a person
            GameObject obj = GameObject.Find(overlapping[0]);
            box boxComponent = obj.GetComponent<box>();
            Person personComponent = obj.GetComponent<Person>();

            // It's a box! Add item and hide it
            if (boxComponent != null)
            {
                Debug.Log("Colliding with a box!");
                boxComponent.addObject(this.gameObject);
                this.gameObject.SetActive(false);
            }
            
            // It's a person! Give them the item for validation
            else if (personComponent != null)
            {
                Debug.Log("Colliding with a person!");
                personComponent.ValidateItem(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entered collider for " + other.name);
        overlapping.Add(other.name);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("exited collider for " + other.name);
        int index = overlapping.FindIndex(entry => entry == other.name);
        if (index >= 0) {
            overlapping.RemoveAt(index);
        }
    }
}
