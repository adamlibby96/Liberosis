using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private GameObject consumeBtn;

    private Selectable selectable;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        consumeBtn.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(null);
        consumeBtn.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        consumeBtn.SetActive(false);
        selectable = transform.GetComponent<Selectable>();
    }   
}
