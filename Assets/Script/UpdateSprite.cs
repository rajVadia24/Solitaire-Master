using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite CardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private DeckManager deckManager;

    private void Awake()
    {
       // deckManager = DeckManager.instance;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = DeckManager.instance.GenerateDeck();
        deckManager = FindObjectOfType<DeckManager>();
        int i = 0;
        foreach (string card in deck)
        {
            if(this.name == card)
            {
                CardFace = deckManager.cardFace[i];
                break;
            }
            i++;
          
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = CardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack; 
        }
    }
}
