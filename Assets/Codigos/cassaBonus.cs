using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cassaBonus : MonoBehaviour
{
    
    public string clonBala;
    public GameObject player;//IA
    
    Vector3 posicionInicial;//IA

    

    
    private Renderer objectRenderer;
    public GameObject Tesoro;
    
    



    private void Awake() {
    //gestorSonido = audioManager.Instance;
    }

    

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        
        
        objectRenderer = GetComponent<Renderer>();  // Ottiene il componente Renderer dell'enemigo

        
        


    }

    void Update(){
        

    }

    void OnTriggerEnter2D(Collider2D col){

        clonBala = col.gameObject.name;

       
        
        
        if(clonBala == "balafuego(Clone)"){
            
            //principalScript.Enemigos++;
            StartCoroutine(ChangeColorTemporarily());
            
            
            
            Destroy(this.gameObject, 0.3f);
            GameObject clonedTesoro = Instantiate(Tesoro, transform.position, Quaternion.identity);
            
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
