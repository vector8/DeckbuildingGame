using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableCard : MonoBehaviour
{
    public TextMeshPro costText, titleText, descriptionText;
    public TextMeshPro attackText, healthText;
    public GameObject attackBg, healthBg;
    public SpriteRenderer spriteRenderer;
    public Vector2 mouseOffset = Vector2.zero;
    public bool isMoving = false;

    private CardData data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    public void initialize(CardData card)
    {
        data = card;
        costText.text = card.cost.ToString();
        titleText.text = LocalizationManager.instance.getLocalizedString(card.cardName);
        if(card.effects.Count == 1 && card.effects[0].effectType == CardData.CardEffect.EffectType.Summon)
        {
            // this is a creature, render it differently.
            attackBg.SetActive(true);
            healthBg.SetActive(true);
            attackText.gameObject.SetActive(true);
            healthText.gameObject.SetActive(true);
            attackText.text = card.effects[0].creatureSummoned.damage.ToString();
            healthText.text = card.effects[0].creatureSummoned.health.ToString();
            descriptionText.text = card.effects[0].creatureSummoned.generateDescription();
        }
        else
        {
            descriptionText.text = card.generateDescription();
        }
        spriteRenderer.sprite = card.image;
    }

    private void OnMouseDown()
    {
        isMoving = true;

    }

    private void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;

            // code here to do stuff with card depending on what it was dragged over
            if (transform.position.y > -0.25f)
            {
                // not in hand
            }
            else
            {
                // put back in hand
                LocalPlayer.instance.hand.Remove(this);
                bool found = false;
                for (int i = 0; i < LocalPlayer.instance.hand.Count; i++)
                {
                    if (transform.position.x < LocalPlayer.instance.hand[i].transform.position.x)
                    {
                        LocalPlayer.instance.hand.Insert(i, this);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    LocalPlayer.instance.hand.Add(this);
                }
            }
        }
    }
}
