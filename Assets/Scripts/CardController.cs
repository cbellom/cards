using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardController : MonoBehaviour {
    public GameObject match;
    private Card card;
    private Text cardText;
    private Image cardImage;
    private Button cardButton;
    private MatchController matchController;
    private Sprite defaultCardBackground;

    void Start() {
        cardText = gameObject.GetComponentInChildren<Text>();
        cardImage = gameObject.GetComponentInChildren<Image>();
        cardButton = gameObject.GetComponentInChildren<Button>();
        cardButton.onClick.AddListener(() => HandleCardClicked());
        matchController = GameObject.FindObjectOfType<MatchController>();

        defaultCardBackground = cardButton.GetComponent<Image>().sprite;
    }

    void HandleCardClicked()
    {
        SelectCard();
    }

    private void SelectCard()
    {
        cardText.text = card.nameCard;
        cardImage.sprite = card.imageCard;
        matchController.SelectCard(this.gameObject);
    }

    public void HideCard()
    {
        cardText.text = "";
        cardImage.sprite = defaultCardBackground;
    }

    public void SetCard(Card card)
    {
        this.card = card;
    }

    public void DisableCard() {
        cardButton.onClick.RemoveAllListeners();
        cardButton.gameObject.SetActive(false);
        cardText.gameObject.SetActive(false);
    }
}
