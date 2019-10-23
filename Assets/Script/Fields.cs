using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fields : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card)
            card.DefaultParent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
