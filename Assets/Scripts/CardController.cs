using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardController : MonoBehaviour {
    private Card card;
    private Text cardText;
    private Image cardImage;
    private Button cardButton;

    void Start() {
        cardText = gameObject.GetComponentInChildren<Text>();
        cardImage = gameObject.GetComponentInChildren<Image>();
        cardButton = gameObject.GetComponentInChildren<Button>();
        cardButton.onClick.AddListener(() => HandleCardClicked());
    }

    void HandleCardClicked()
    {
        ShowCard();
    }

    private void ShowCard()
    {
        cardText.text = card.nameCard;
        cardImage.sprite = card.imageCard;
    }

    private void HideCard()
    {
        cardText.text = "";
        cardImage.sprite = null;
    }

    public void SetCard(Card card)
    {
        this.card = card;
    }
}
