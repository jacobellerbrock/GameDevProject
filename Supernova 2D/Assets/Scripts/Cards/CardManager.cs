using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public static CardManager singleton;
    public List<Sprite> availableCards = new List<Sprite>();
    public List<GameObject> availableSpells;
    public List<Card> deck = new List<Card>();
    public GameObject[] cardHolders;
    public int[] cardID = {-1, -1, -1, -1};
    public bool[] availableSlots;

    public int selected = -1;
    
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        foreach (GameObject holder in cardHolders)
        {
            holder.gameObject.SetActive(false);
            holder.GetComponent<Animator>().enabled = false;
        }

        deck.Add(new Card(availableCards[0]));
    }

    private void Start()
    {
        DrawCard();
    }

    private void Update()
    {
        if (AllHoldersEmpty()) selected = -1;

        if (selected < 0) return;

        for (int i = 0; i < cardHolders.Length; i++)
            if (i != selected)
            {
                cardHolders[i].GetComponent<Animator>().enabled = false;
                cardHolders[i].GetComponent<Animator>().StopPlayback();
                cardHolders[i].GetComponent<RectTransform>().transform.position =
                    new Vector3(cardHolders[i].GetComponent<RectTransform>().transform.position.x, 0);
            }

        cardHolders[selected].GetComponent<Animator>().enabled = true;
        cardHolders[selected].GetComponent<Animator>().Play("Bounce");
    }

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            int randomNumber = Random.Range(0, deck.Count);
            Card randCard = deck[randomNumber];

            for (int i = 0; i < availableSlots.Length; i++)
            {
                if (availableSlots[i])
                {
                    cardHolders[i].gameObject.SetActive(true);
                    availableSlots[i] = false;
                    cardHolders[i].GetComponent<Image>().sprite = randCard.image;
                    cardID[i] = randomNumber;
                    return;
                }
            }
        }
    }

    public void UseCard()
    {
        Debug.Log(deck[0] != null);
        Debug.Log(cardID[selected]);
        Debug.Log(deck[cardID[selected]] != null);
        deck[cardID[selected]].spell.Cast();
        RemoveCard(selected);
    }

    public void RemoveCard(int n)
    {
        if (availableSlots[n]) return;
        cardHolders[n].gameObject.SetActive(false);
        availableSlots[n] = true;
        cardID[n] = -1;
    }

    private bool AllHoldersEmpty()
    {
        foreach (bool slot in availableSlots) if (!slot) return false;
        return true;
    }

    public void ChangeSelected(int n)
    {
        if (AllHoldersEmpty()) return;

        List<int> possibleSlots = new List<int>();
        for (int i = 0; i < availableSlots.Length; i++) if (!availableSlots[i]) possibleSlots.Add(i);

        int cardSelected = possibleSlots.IndexOf(selected);
        cardSelected += n;
        if (cardSelected < 0) cardSelected = possibleSlots.Count - 1;
        if (cardSelected > possibleSlots.Count - 1) cardSelected = 0;

        selected = possibleSlots[cardSelected];
    }
    
    // 0 1 2 3
    //   1 2
    // possibleSlots = [1, 2]
    // cardSelected = 0
}
