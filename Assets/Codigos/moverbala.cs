using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverbala : MonoBehaviour
{
    public float speed = 5f; // Velocità della bala

    private Vector3 direction; // Direzione di lancio della bala

    private void Start()
    {
        // Determina la direzione in base alla variabile "direccionBala" del personaggio
        if (Movimiento.direccionBala)
        {
            // Il personaggio è girato verso destra, lancia verso la direzione x+
            direction = Vector3.right;
        }
        else
        {
            // Il personaggio è girato verso sinistra, lancia verso la direzione x-
            direction = Vector3.left;
        }
        {
        Destroy (gameObject, 2f);
    }
    }

    private void Update()
    {
        // Muovi la bala nella direzione calcolata
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // La bala ha colpito un nemico, esegui l'azione desiderata (ad esempio, danni al nemico)
            // Puoi aggiungere qui il codice per l'effetto dell'impatto della bala sul nemico
            Destroy(gameObject);
        }
    }
}












/*{
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Movimiento.direccionBala == true && Movimiento.ParardireccionBala == false){
        transform.Translate (new Vector2 ( Time.deltaTime * 7,0));
        }

        if(Movimiento.direccionBala == false && Movimiento.ParardireccionBala == true){
        transform.Translate (new Vector2 ( -Time.deltaTime * 7,0));
        }
    }
}*/
