using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goals : MonoBehaviour
{
    //private audioManager gestorSonido;

    
   private void Awake() {
    //gestorSonido = audioManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    //void OnTriggerEnter2D(){              ////Collision also with enemy
       // principalScript.Score +=10;
        
       // Destroy(this.gameObject, 0.5f);
       // gestorSonido.GetComponent<audioManager>().sonidoPuntos();
    //}

    
    
    void OnTriggerEnter2D(Collider2D other)    // Collision only with player
{
    if(other.CompareTag("Player"))
    {
        principalScript.Score +=10;
        Destroy(this.gameObject, 0.5f);
        //gestorSonido.GetComponent<audioManager>().sonidoPuntos();
    }
}
}
