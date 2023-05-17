using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigEnemigo : MonoBehaviour
{
    public string clonBala;  // Nome dell'istanza della bala
    public GameObject player;  // Riferimento al giocatore
    float SpeedEnemigo = 1f;  // Velocità di movimento dell'enemigo
    float startMoveDistance = 10f;  // Distanza di inizio movimento verso il giocatore
    float acceleratedSpeed = 2f;  // Moltiplicatore di velocità quando si muove verso il giocatore
    Vector3 posicionInicial;  // Posizione iniziale dell'enemigo
    int nbala = 0;  // Contatore delle istanze di bala
    //public static bool direccionBalaEnemigo = false; 
    //public static bool ParardireccionBalaEnemigo = false;

    private audioManager gestorSonido;  // Gestore audio
    private AudioSource emisorEnemigo;  // Sorgente audio dell'enemigo
    private Renderer objectRenderer;  // Renderer dell'enemigo
    public GameObject balaEnemigo;  // Prefab della bala dell'enemigo
    public string clonBalaEnemigo;

    bool isMovingToPlayer = false;  // Flag che indica se l'enemigo si sta muovendo verso il giocatore

    private void Awake()
    {
        gestorSonido = audioManager.Instance;  // Ottiene l'istanza del gestore audio
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  // Trova il giocatore tramite il tag
        posicionInicial = transform.position;  // Memorizza la posizione iniziale dell'enemigo
        emisorEnemigo = GetComponent<AudioSource>();  // Ottiene il componente AudioSource dell'enemigo
        objectRenderer = GetComponent<Renderer>();  // Ottiene il componente Renderer dell'enemigo

        // Invoca la funzione CloneBalaEnemigo() ogni metà di secondo
        InvokeRepeating("CloneBalaEnemigo", 0f, 0.50f);
    }

    void Update()
    {
        float distancia = Vector3.Distance(player.transform.position, transform.position);  // Calcola la distanza tra l'enemigo e il giocatore

        if (!isMovingToPlayer && distancia < startMoveDistance)
        {
            isMovingToPlayer = true;  // L'enemigo inizia a muoversi verso il giocatore
            SpeedEnemigo *= acceleratedSpeed;  // Aumenta la velocità dell'enemigo
        }

        if (isMovingToPlayer)
        {
            Vector3 objetivo = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);  // Calcola la posizione obiettivo verso cui muoversi (mantenendo l'altezza dell'enemigo)
            float velocidadFija = SpeedEnemigo * Time.deltaTime;  // Calcola la velocità fissa in base al tempo
            transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidadFija);  // Muove l'enemigo verso l'obiettivo con la velocità fissa
        }

        Debug.DrawLine(transform.position, player.transform.position, Color.green);  // Disegna una linea verde per visualizzare la direzione verso il giocatore
    }





    

    void CloneBalaEnemigo()
        {
            if (Vector3.Distance(player.transform.position, transform.position) < startMoveDistance)
            {
                GameObject clone = Instantiate(balaEnemigo, transform.position, Quaternion.identity);  // Crea una copia della balaEnemigo nella posizione corrente dell'enemigo
                Vector3 direccion = player.transform.position - transform.position;  // Calcola la direzione verso cui puntare la bala (direzione del giocatore rispetto all'enemigo)
                clone.transform.right = -direccion.normalized;  // Imposta la direzione della bala verso il giocatore normalizzando il vettore direzione
                
            }
        }




        // Gestisce le collisioni con i collider2D
        void OnTriggerEnter2D(Collider2D col)
        {
            clonBala = col.gameObject.name;  // Ottiene il nome dell'oggetto che ha causato la collisione

            if (clonBala == "balafuego(Clone)")
            {
                nbala++;  // Incrementa il contatore delle istanze di bala

                emisorEnemigo.PlayOneShot(gestorSonido.GetComponent<audioManager>().sonidoBola, 1f);  // Riproduce un suono usando l'audioManager

                if (nbala == 20)
                {
                    Destroy(this.gameObject, 0.3f);  // Se sono state create 20 istanze di bala, distruggi l'enemigo dopo 0.3 secondi
                }
                else
                {
                    StartCoroutine(ChangeColorTemporarily());  // Altrimenti avvia la coroutine per cambiare temporaneamente il colore dell'enemigo
                }
            }
            else if (clonBala == "Personaje")
            {
                principalScript.Vida--;  // Decrementa la vita del personaggio principale (presumibilmente presente in principalScript)
                gestorSonido.GetComponent<audioManager>().sonidoDead();  // Riproduce un suono di morte usando l'audioManager
            }

            clonBalaEnemigo = col.gameObject.name;  // Ottiene il nome dell'oggetto che ha causato la collisione

            if (clonBalaEnemigo == "balaenemigo(Clone)")
            {
                  // Incrementa il contatore delle istanze di bala

                //emisorEnemigo.PlayOneShot(gestorSonido.GetComponent<audioManager>().sonidoBola, 1f);  // Riproduce un suono usando l'audioManager

             } /*else if (clonBalaEnemigo == "Personaje")
            {
                principalScript.Vida--;  // Decrementa la vita del personaggio principale (presumibilmente presente in principalScript)
                //gestorSonido.GetComponent<audioManager>().sonidoDead();  // Riproduce un suono di morte usando l'audioManager
            }*/

            
        }

       
       
       
       
       
       
       
       
       
        // Coroutine che cambia temporaneamente il colore dell'enemigo
        IEnumerator ChangeColorTemporarily()
        {
            Color originalColor = objectRenderer.material.color;  // Memorizza il colore originale dell'enemigo
            objectRenderer.material.color = Color.red;  // Imposta il colore dell'enemigo a rosso

            yield return new WaitForSeconds(0.1f);  // Aspetta per 0.1 secondi

            objectRenderer.material.color = originalColor;  // Ripristina il colore originale dell'enemigo
        }
}