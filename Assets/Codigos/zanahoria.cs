using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zanahoria : MonoBehaviour
{
    // private audioManager gestorSonido;

    private void Awake()
    {
        // gestorSonido = audioManager.Instance;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Animazione collected
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);

            principalScript.Zanahoria += 1;

           // gestorSonido.GetComponent<audioManager>().sonidoPuntos();
        }
    }
}

