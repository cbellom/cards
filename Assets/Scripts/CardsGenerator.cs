using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject cardsGrid;
    public Data data;

    void Start() {
        CreateCouplesCards(data.listCards);
    }

    void CreateCouplesCards(List<CoupleCards> listCoupleCards)
    {
        foreach (CoupleCards coupleCard in listCoupleCards)
        {
            CreateCard(coupleCard.firstCard);
            CreateCard(coupleCard.secondCard);
        }
    }

    private void CreateCard(Card card)
    {
        Vector3 position = cardsGrid.transform.position;
        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity) as GameObject;
        newCard.transform.SetParent(cardsGrid.gameObject.transform, false);

        CardController cardController = newCard.GetComponent<CardController>();
        cardController.SetCard(card);
        
    }
}
