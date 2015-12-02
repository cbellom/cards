using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject cardsGrid;
    public Data data;

    void Start() {
        List<GameObject> cards = CreateCouplesCards(data.listCards);
        cards = ShuffleCards(cards);
        InsertCardsIntoGrid(cards);
    }

    private List<GameObject> CreateCouplesCards(List<CoupleCards> listCoupleCards)
    {
        List<GameObject> cards = new List<GameObject>();
        foreach (CoupleCards coupleCard in listCoupleCards)
        {
            CreateCouple(cards, coupleCard);
        }
        return cards;
    }

    private void CreateCouple(List<GameObject> cards, CoupleCards coupleCard)
    {
        GameObject firstCard = CreateCard(coupleCard.firstCard);
        GameObject secondCard = CreateCard(coupleCard.secondCard);
        SetMatchingCards(firstCard, secondCard);
        cards.Add(firstCard);
        cards.Add(secondCard);
    }

    private GameObject CreateCard(Card card)
    {
        Vector3 position = cardsGrid.transform.position;
        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity) as GameObject;

        CardController cardController = newCard.GetComponent<CardController>();
        cardController.SetCard(card);
        return newCard;
    }

    private void SetMatchingCards(GameObject firstCard, GameObject secondCard)
    {
        CardController cardController = firstCard.GetComponent<CardController>();
        cardController.match = secondCard;

        cardController = secondCard.GetComponent<CardController>();
        cardController.match = firstCard;
    }

    private List<GameObject> ShuffleCards(List<GameObject> cards)
    {
        List<GameObject> randomCards = new List<GameObject>();
        while (cards.Count != 0)
        {
            GameObject g = cards[Random.Range(0, cards.Count)];
            cards.Remove(g);
            randomCards.Add(g);
        }

        return randomCards;
    }

    private void InsertCardsIntoGrid(List<GameObject> cards)
    {
        foreach (GameObject card in cards)
        {
            card.transform.SetParent(cardsGrid.gameObject.transform, false);
        }
    }
}
