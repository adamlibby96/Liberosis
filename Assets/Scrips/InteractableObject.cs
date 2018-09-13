using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] private Material original;
    [SerializeField] private Material outlined;

    [SerializeField] private Type objType;

    public void outlineObject()
    {
        transform.GetComponent<MeshRenderer>().material = outlined;
    }

    public void originalMaterial()
    {
        transform.GetComponent<MeshRenderer>().material = original;
    }
    
    public Type getType()
    {
        return objType;
    }
}
