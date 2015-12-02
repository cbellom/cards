using UnityEngine;
using System.Collections;

public class MatchController : MonoBehaviour {

    private GameObject cardSelected;

    public void SelectCard(GameObject card) {
        if (cardSelected == null)
        {
            cardSelected = card;
        }
        else
        {
            if (isMatchCardWithSelected(card))
                StartCoroutine(DisableMatingCards(card));
            else
                StartCoroutine(HideNotMatchingCards(card));
        }
    }

    private bool isMatchCardWithSelected(GameObject card)
    {
        return GetCardController(card).match == cardSelected;
    }

    private IEnumerator DisableMatingCards(GameObject card)
    {
        yield return new WaitForSeconds(1);
        GetCardController(card).DisableCard();
        GetCardController(cardSelected).DisableCard();
        cardSelected = null;
    }

    private IEnumerator HideNotMatchingCards(GameObject card)
    {
        yield return new WaitForSeconds(1);
        GetCardController(card).HideCard();
        GetCardController(cardSelected).HideCard();
        cardSelected = null;
    }

    private CardController GetCardController(GameObject card)
    {
        return card.GetComponent<CardController>() as CardController;
    }
}
