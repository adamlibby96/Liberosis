using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interact : MonoBehaviour {

    [SerializeField] private Camera fpsCam;
    [SerializeField] private float interactDistance = 3.0f;
    [SerializeField] private InventorySystem inventory;
    [SerializeField] private Text interactText;
   


    private GameObject previousObject;

    private void Start()
    {
        interactText.enabled = false; 
    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetKeyDown(KeyCode.E))
        //      {
        //          interact();
        //      }

        // constantly check for interactable objects
        interact();
        
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Debug.Log(inventory.displayAll());
        //}
    
	}

    private void interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, interactDistance))
        {
            //currentObject = hit.transform.gameObject;
            InteractableObject obj = hit.transform.GetComponent<InteractableObject>();
            if (obj)
            {
                //Debug.Log("Found");
                previousObject = obj.gameObject;
                previousObject.GetComponent<InteractableObject>().outlineObject();
                interactText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickUpItem(previousObject);
                    interactText.enabled = false;
                }
            }
            else
            {
                //Debug.Log("Not interactable");
            }
        } else
        {
            if (previousObject)
            {
                previousObject.GetComponent<InteractableObject>().originalMaterial();
                previousObject = null;
                interactText.enabled = false;
            }
        }

        //if (currentObject != previousObject)
        //{
        //    previousObject.GetComponent<InteractableObject>().originalMaterial();
        //}
    }

    private void pickUpItem(GameObject obj)
    {
        bool added = false;
        Type tempType = obj.GetComponent<InteractableObject>().getType();
        switch (tempType)
        {
            case Type.Health:
                inventory.addItem("health", Type.Health);
                added = true;
                break;
            case Type.Puzzle:
                inventory.addItem("puzzle", Type.Puzzle);
                added = true;
                break;
            case Type.Weapon:
                inventory.addItem("weapon", Type.Weapon);
                added = true;
                break;
            default:
                Debug.Log("Could not determine object type.");
                break;
        }
        if (added)
        {
            Destroy(obj.gameObject);
        }
    }
}
