using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverbalaenemigo : MonoBehaviour
{
    public float speed = 3f; // Velocità del missile

    private Transform target; // Riferimento al transform del personaggio

    private void Start()
    {
        // Trova il GameObject con il tag "Player" e ottiene il riferimento al suo transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            // Il personaggio non è stato trovato, distruggi il missile
            Destroy(gameObject);
            return;
        }

        // Calcola la direzione verso il personaggio
        Vector3 direction = (target.position - transform.position).normalized;

        // Muovi il missile nella direzione calcolata
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Il missile ha colpito il personaggio, esegui l'azione desiderata (ad esempio, danni al personaggio)
            // Puoi aggiungere qui il codice per l'effetto dell'impatto del missile sul personaggio
            Destroy(gameObject);
            principalScript.Vida--;  // Decrementa la vita del personaggio principale (presumibilmente presente in principalScript)
        }
    }
}









/*{

    //public GameObject balaEnemigo;  // Prefab della bala dell'enemigo
    //private string clonBalaEnemigo;  // Nome dell'oggetto che ha causato la collisione

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Movimiento.direccionBala == true && Movimiento.ParardireccionBala == false)
        {
            transform.Translate(new Vector2(Time.deltaTime * 7, 0));
        }

        if (Movimiento.direccionBala == false && Movimiento.ParardireccionBala == true)
        {
            transform.Translate(new Vector2(-Time.deltaTime * 7, 0));
        }
    }

    
}*/















/*{
    // Altre dichiarazioni di variabili...

    void Start()
    {
        Destroy (gameObject, 1f);
    }

    void Update()
    {
        // Controlla se la variabile statica "direccionBalaEnemigo" in Movimiento è true
        // e la variabile statica "ParardireccionBalaEnemigo" in Movimiento è false
        if (Movimiento.direccionBalaEnemigo == true && Movimiento.ParardireccionBalaEnemigo == false)
        {
            // Sposta l'oggetto lungo l'asse X verso destra
            transform.Translate(new Vector2(Time.deltaTime * 7, 0));
        }

        // Controlla se la variabile statica "direccionBalaEnemigo" in Movimiento è false
        // e la variabile statica "ParardireccionBalaEnemigo" in Movimiento è true
        if (Movimiento.direccionBalaEnemigo == false && Movimiento.ParardireccionBalaEnemigo == true)
        {
            // Sposta l'oggetto lungo l'asse X verso sinistra
            transform.Translate(new Vector2(-Time.deltaTime * 7, 0));
        }
    }
}*/




