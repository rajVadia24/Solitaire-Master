using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private DeckManager deckManager;

    private void Awake()
    {
        deckManager = DeckManager.instance;
        selectable = Selectable.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = DeckManager.instance.GenerateDeck();
        int i = 0;
        foreach (string card in deck)
        {
            if(this.name == card)
            {
                cardFace = deckManager.cardFace[i];
                break;
            }
            i++;
            spriteRenderer = GetComponent<SpriteRenderer>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack; 
        }
    }
}
