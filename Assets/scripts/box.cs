using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Texture2D openSprite;
    public Texture2D closedSprite;
    public List<GameObject> inventory;
    public AudioClip boxOpen;
    public AudioClip boxDrop;
    private List<GameObject> lastOwnedItems = new List<GameObject>();
    private bool isOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject obj) {
        GetComponent<AudioSource>().PlayOneShot(boxDrop, 0.5f);
        inventory.Add(obj);
        obj.GetComponent<Item>().SetBox(gameObject.name);
    }

    public void OnMouseUp() {
        GetComponent<AudioSource>().PlayOneShot(boxOpen, 0.4f);
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        if (!isOpen)
        {
            sprite.sprite = Sprite.Create(openSprite, new Rect(0.0f, 0.0f, openSprite.width, openSprite.height), new Vector2(0.5f, 0.5f), 100.0f);
            isOpen = true;
            for (int index = 0; index < inventory.Count; index++)
            {
                inventory[index].transform.position = RandomPosition.GetRandomTablePosition();
                inventory[index].SetActive(true);
            }
            lastOwnedItems = new List<GameObject>(inventory);
            inventory.Clear();
        } 
        else
        {
            sprite.sprite = Sprite.Create(closedSprite, new Rect(0.0f, 0.0f, openSprite.width, openSprite.height), new Vector2(0.5f, 0.5f), 100.0f);
            isOpen = false;
            for(int i = 0; i < lastOwnedItems.Count; i++)
            {
                GameObject item = lastOwnedItems[i];
                if(item != null && item.GetComponent<Item>().GetBox() == gameObject.name)
                {
                    inventory.Add(item);
                    item.SetActive(false);
                }
            }
            lastOwnedItems.Clear();
        }

    }
}
