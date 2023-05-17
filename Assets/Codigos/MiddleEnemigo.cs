using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemigo : MonoBehaviour
{
    
    public string clonBala;
    public GameObject player;//IA
    float SpeedEnemigo = 1f;//IA
    float DistanciaPlayer = 42f;//IA
    Vector3 posicionInicial;//IA
    int nbala = 0 ;

    private audioManager gestorSonido;

    private AudioSource emisorEnemigo;
    private Renderer objectRenderer;
    
    



    private void Awake() {
    gestorSonido = audioManager.Instance;
    }

    

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        posicionInicial = transform.position;
        emisorEnemigo = GetComponent<AudioSource>();
        objectRenderer = GetComponent<Renderer>();

        
        


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

            nbala++;
            emisorEnemigo.PlayOneShot( gestorSonido.GetComponent<audioManager>().sonidoBola,1f);
            if (nbala == 20)
            { Destroy(this.gameObject, 0.3f);
                
            }else
            {
                StartCoroutine(ChangeColorTemporarily());
            }
            
            
            

        }

        if(clonBala == "Personaje"){

            principalScript.Vida--;
            //player.transform.position = new Vector2 (-1.18f,1.44f);
            

            gestorSonido.GetComponent<audioManager>().sonidoDead();
            
        }
       


    }

    IEnumerator ChangeColorTemporarily()
    {
        Color originalColor = objectRenderer.material.color;
        objectRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        objectRenderer.material.color = originalColor;
    }






}
