using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static LocalPlayer instance = null;

    public GameObject cardPrefab;

    public List<InteractableCard> hand;
    public List<CardData> deck;

    private const float CARD_WIDTH = 0.32f;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        shuffleDeck();
        drawCard();
        drawCard();
        drawCard();
        drawCard();
        drawCard();
    }

    // Update is called once per frame
    void Update()
    {
        float currentPos = -((hand.Count * CARD_WIDTH * 0.5f) - (0.5f * CARD_WIDTH));

        for(int i = 0; i < hand.Count; i++)
        {
            if(!hand[i].isMoving)
            {
                hand[i].transform.position = new Vector3(currentPos, -0.5f, hand[i].transform.position.z);
            }

            currentPos += CARD_WIDTH;
        }
    }

    public void shuffleDeck()
    {
        List<CardData> shuffled = new List<CardData>();
        int deckCount = deck.Count;
        for (int i = 0; i < deckCount; i++)
        {
            int index = Random.Range(0, deck.Count);
            shuffled.Add(deck[index]);
            deck.RemoveAt(index);
        }
        deck = shuffled;
    }

    public void drawCard()
    {
        if(deck.Count > 0)
        {
            CardData data = deck[0];
            deck.RemoveAt(0);

            GameObject cardInstance = Instantiate(cardPrefab);
            InteractableCard interactableCard = cardInstance.GetComponent<InteractableCard>();
            interactableCard.initialize(data);

            hand.Add(interactableCard);
        }
    }
}
