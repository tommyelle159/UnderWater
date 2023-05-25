using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goals : MonoBehaviour
{
    //private audioManager gestorSonido;

    
  private void Awake() {
    //gestorSonido = audioManager.Instance;
    }

    
    
    //void OnTriggerEnter2D(){              ////Collision also with enemy
       // principalScript.Score +=10;
        
       // Destroy(this.gameObject, 0.5f);
       // gestorSonido.GetComponent<audioManager>().sonidoPuntos();
    //}

    
    
    public void OnTriggerEnter2D(Collider2D collision)    // Collision only with player
{
    //if(other.CompareTag("Player"))
    if (collision.CompareTag("Player"))
    { 
        //animacion collected
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, 0.5f);

        principalScript.Score +=10;
       
        //gestorSonido.GetComponent<audioManager>().sonidoPuntos();
    }
}
}
