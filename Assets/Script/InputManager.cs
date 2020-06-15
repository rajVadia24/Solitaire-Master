using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Inputs();
    }
    // Update is called once per frame
    void Inputs()
    {
      if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider.CompareTag("Deck"))
            {
                Deck();
            }
            else if (hit.collider.CompareTag("Card"))
            {
                Card();

            }
            else if (hit.collider.CompareTag("Top"))
            {
                Top();
            }
            else if (hit.collider.CompareTag("Bottom"))
            {
                Bottom();
            }
            else if(hit.collider.CompareTag("Ground"))
            {
                print("Ground");
            }
         
        }
    }

    void Deck()
    {
        print("Deck");
    }
    void Card()
    {
        print("Card");
    }
    void Top()
    {
        print("Top");
    }
    void Bottom()
    {
        print("Bottom");
    }
}
