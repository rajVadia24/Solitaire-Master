﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Sprite[] cardFace;
    public static DeckManager instance;

    public static string[] suits = new string[] { "C", "H", "S", "D" };
    public static string[] value = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayingCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayingCards()
    {
        deck = GenerateDeck();
        foreach(string card in deck)
        {
            print(card);
        }
        Shuffle(deck);
        CardDeal();
    }
   public  List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach(string s in suits)
        {
            foreach(string v in value)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while(n>1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void CardDeal()
    {
        float yoffSet = 0f;
        float zOffset = 0.05f;
        foreach(string card in deck)
        {
            GameObject NewCard = Instantiate(cardPrefab, new Vector3(transform.position.x, transform.position.y - yoffSet, transform.position.z - zOffset), Quaternion.identity);
            NewCard.name = card;
            Selectable.instance.faceUp = true;
            yoffSet += 0.1f;
            zOffset += 0.05f;
        }
    }
}
