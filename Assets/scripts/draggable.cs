using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    private bool isDragging = false;
    private List<string> overlapping = new List<string>();

    void Start() {
    }
    // Update is called once per frame
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
        isDragging = false;
        Debug.Log("letting go");
        // if colliding with a box, add obj to box list, disappear obj
        if(overlapping.Count == 1) {
            Debug.Log("overlapping one " + overlapping[0]);
            GameObject box = GameObject.Find(overlapping[0]);
            box.GetComponent<box>().addObject(this.gameObject);
            // hide gameobject
            this.gameObject.SetActive(false);
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
