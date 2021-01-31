using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    private bool isDragging = false;
    private List<string> overlapping = new List<string>();
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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
            Box boxComponent = obj.GetComponent<Box>();
            Person personComponent = obj.GetComponent<Person>();

            // It's a box! Add item and hide it
            if (boxComponent != null)
            {
                Debug.Log("Colliding with a box!");
                gameManager.PutItemInBox(this.gameObject, boxComponent);
            }
            
            // It's a person! Give them the item for validation
            else if (personComponent != null)
            {
                Debug.Log("Colliding with a person!");
                gameManager.ValidateItemForPerson(this.gameObject);
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
