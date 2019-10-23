using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    GameObject EndOfTheRoad;
    float speed = 1f;
    Camera MainCamera;
    Vector2 indent;
    public Transform DefaultParent;
    public Image Logo;
    public Text Name;
    GameObject DeckField;
    GameObject Hand;
    GameObject Delete;

    // Start is called before the first frame update
    void Start()
    {
        ShowCard(CardManeger.AllCards[Random.Range(0, 51)]);
        DeckField = GameObject.Find("Deck");
        Hand = GameObject.Find("hand");
        Delete = GameObject.Find("Delete");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == DeckField.transform)
            Movement(Hand);
        if (transform.parent == Delete.transform)
            Destroy(transform.gameObject, 0.2f);

    }

    public void Movement(GameObject EndOfTheRoad)
    {
        float Dist = Vector3.Distance(transform.position, EndOfTheRoad.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Hand.transform.position, speed);
        if (Dist < 0.5)
            transform.SetParent(EndOfTheRoad.transform);



    }
    void Awake()
    {
        MainCamera = Camera.allCameras[0];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        indent = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        DefaultParent =  transform.parent;
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = position + indent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    public void ShowCard(CardDeck x)
    {
        Logo.sprite = x.Logo;
        Logo.preserveAspect = true;
        Name.text = x.Name;
    }
}
