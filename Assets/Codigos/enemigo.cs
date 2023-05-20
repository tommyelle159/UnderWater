using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemigo : MonoBehaviour
{
    
    public string clonBala;
    public GameObject player;//IA
    float SpeedEnemigo = 0.6f;//IA
    float DistanciaPlayer = 4f;//IA
    Vector3 posicionInicial;//IA

    private audioManager gestorSonido;

    private AudioSource emisorEnemigo;
    private Renderer objectRenderer;
    



    private void Awake() {
    //gestorSonido = audioManager.Instance;
    }

    

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        posicionInicial = transform.position;
        //emisorEnemigo = GetComponent<AudioSource>();
        objectRenderer = GetComponent<Renderer>();  // Ottiene il componente Renderer dell'enemigo

        
        


    }

    void Update(){
        Vector3 Objetivo = posicionInicial; //IA
        float distancia = Vector3.Distance(player.transform.position,transform.position);
        
        if(distancia < DistanciaPlayer){
            Objetivo= player.transform.position;
        }
        float Velocidadfija = SpeedEnemigo*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,Objetivo,Velocidadfija);

        Debug.DrawLine(transform.position,Objetivo, Color.green); //IA se visualiza de la scena

    }

    void OnTriggerEnter2D(Collider2D col){

        clonBala = col.gameObject.name;

       
        
        
        if(clonBala == "balafuego(Clone)"){
            
            principalScript.Enemigos++;
            StartCoroutine(ChangeColorTemporarily());
            
            
            //emisorEnemigo.PlayOneShot( gestorSonido.GetComponent<audioManager>().sonidoBola,1f);
            Destroy(this.gameObject, 0.3f);
        }

        if(clonBala == "Personaje"){

            principalScript.Vida--;
            player.transform.position = new Vector2 (-1.18f,1.44f);
            

            //gestorSonido.GetComponent<audioManager>().sonidoDead();
            
        }
        
       


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
