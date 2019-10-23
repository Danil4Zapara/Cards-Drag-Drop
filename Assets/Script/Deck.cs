using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct CardDeck
{
    public string Name;
    public Sprite Logo;


    public CardDeck(string name, string logoPath)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
    }
}
    public static class CardManeger
    {
        public static List<CardDeck> AllCards = new List<CardDeck>();
    }

public class Deck : MonoBehaviour
{
    List<string> ValueCards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "В", "Д", "К", "А" };
    public GameObject PrefabCart;
    GameObject CreatedCard;
    public GameObject DeckField;
    private void Awake()
    {
        for (int i = 0; i < 13; i++)
        {
            CardManeger.AllCards.Add(new CardDeck(ValueCards[i], "Cards/Bub"));
            CardManeger.AllCards.Add(new CardDeck(ValueCards[i], "Cards/Cher"));
            CardManeger.AllCards.Add(new CardDeck(ValueCards[i], "Cards/Pik"));
            CardManeger.AllCards.Add(new CardDeck(ValueCards[i], "Cards/Tref"));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Invoke("CreationCard", i);
        }
    }

    public void CreationCard()
    {
        CreatedCard = Instantiate(PrefabCart, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        CreatedCard.transform.SetParent(DeckField.transform);
        CreatedCard.transform.localScale = new Vector3(1, 1, 1);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
