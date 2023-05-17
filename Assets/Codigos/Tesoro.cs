using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesoro : MonoBehaviour

{
    private audioManager gestorSonido;

    
   private void Awake() {
    gestorSonido = audioManager.Instance;
    }

    
    
    void OnTriggerEnter2D(Collider2D other)    // Collision only with player
{
    if(other.CompareTag("Player"))
    {
        principalScript.Vida++;
        Destroy(this.gameObject, 0.5f);
        gestorSonido.GetComponent<audioManager>().sonidoPuntos();
    }
}
}