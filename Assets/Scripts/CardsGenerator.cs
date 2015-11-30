using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject cardsGrid;
    public Data data;

    void Start() {
        
    }

    void CreateCouplesCards(List<CoupleCard> listCoupleCards)
    {
        foreach (CoupleCard coupleCard in listCoupleCards) {
            CreateCard(coupleCard.nameCard, coupleCard.imageCard);
        }
    }

    private GameObject CreateCard(string name, Sprite image)
    {
        var pos = new Vector3(0, 0, 0);
        GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity) as GameObject;
        Card cardController = newCard.GetComponent<Card>();
        cardController.cardName = name;
        cardController.cardBackground = image;
        return newCard;
    }
}
