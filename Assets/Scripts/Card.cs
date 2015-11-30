using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {
    public string cardName;
    public Sprite cardBackground;

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
        showCard();
    }

    private void showCard()
    {
        cardText.text = cardName;
        cardImage.sprite = cardBackground;
    }

    private void hideCard()
    {
        cardText.text = "";
        cardImage.sprite = null;
    }
}
