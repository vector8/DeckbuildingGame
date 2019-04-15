using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckUI : MonoBehaviour
{
    public TextMeshPro mouseOverText;
    public GameObject mouseOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseOverText.text = LocalPlayer.instance.deck.Count + " Cards Left";
    }

    private void OnMouseEnter()
    {
        mouseOverUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        mouseOverUI.SetActive(false);
    }
}
