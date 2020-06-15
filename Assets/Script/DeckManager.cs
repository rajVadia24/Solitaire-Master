using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject[] bottomsPos;
    public GameObject[] topsPos;
    public Sprite[] cardFace;
    public static DeckManager instance;

    public static string[] suits = new string[] { "C", "H", "S", "D" };
    public static string[] value = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;
    public List<string>[] bottoms;
    public List<string>[] tops;

    private List<string> bottom0 = new List<string>();
    private List<string> bottom1 = new List<string>();
    private List<string> bottom2 = new List<string>();
    private List<string> bottom3 = new List<string>();
    private List<string> bottom4 = new List<string>();
    private List<string> bottom5 = new List<string>();
    private List<string> bottom6 = new List<string>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        bottoms = new List<string>[] { bottom0, bottom1, bottom2, bottom3, bottom4, bottom5, bottom6 };
        PlayingCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayingCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        foreach (string card in deck)
        {
            print(card);
        }
        SolitaireSort();
       StartCoroutine(CardDeal());
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

    IEnumerator CardDeal()
    {
        for (int i = 0; i < 7; i++)
        {
            float yoffSet = 0f;
            float zOffset = 0.05f;
            foreach (string card in bottoms[i])
            {
                yield return new WaitForSeconds(0.05f);
                GameObject NewCard = Instantiate(cardPrefab, new Vector3(bottomsPos[i].transform.position.x, bottomsPos[i].transform.position.y - yoffSet, bottomsPos[i].transform.position.z - zOffset), Quaternion.identity, bottomsPos[i].transform);
                NewCard.name = card;
                if (card == bottoms[i][bottoms[i].Count - 1])
                {
                    NewCard.GetComponent<Selectable>().faceUp = true;
                }
               
                yoffSet += 0.5f;
                zOffset += 0.05f;
            }
        }
    }
    void SolitaireSort()
    {
        for(int i=0;i<7;i++)
        {
            for(int j=i;j<7;j++)
            {
                bottoms[j].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);
            }
        }
    }
}
