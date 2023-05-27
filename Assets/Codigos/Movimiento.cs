using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float Speed = 2f;
    public float Salto = 5f;
    public bool ActivaSalto = true;
    //animacion caida y salto
    // public Rigidbody2D CR;
    //private Collider2D coll;
    //private enum Estado {Quiero, Camina, Salta, Caida}
    
    public Animator controlAnimacion;

    // DA RIMETTEREpublic Animator controlAnimacion;
    public static bool direccionBala = false;
    public static bool ParardireccionBala = false;
    //public string clonBalaEnemigo;
    //public GameObject enemy;
    //public static bool direccionBalaEnemigo = false; 
    //public static bool ParardireccionBalaEnemigo = false;
    private Renderer objectRenderer;
    public GameObject balaEnemigo;  // Prefab della bala dell'enemigo
    private string clonBalaEnemigo;  // Nome dell'oggetto che ha causato la collisione


    

     private void Start()
   
   
    
    {
         
        SceneManager.sceneLoaded += OnSceneLoaded; 
        objectRenderer = GetComponent<Renderer>();  // Ottiene il componente Renderer dell'enemigo

    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;
        if (sceneName == "Nivel1")
        {
            // Posiziona il game object nella posizione desiderata
            transform.position = new Vector3(-1.18f, 1.44f, 0f);
        }
    }

        
        private static Movimiento instance;
        public static Movimiento Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<Movimiento>();
                if (instance == null) {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<Movimiento>();
                    singleton.name = typeof(Movimiento).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }//fin Get

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
         
    


    
    
    // Update is called once per frame
    void Update()
    {      
        if(principalScript.Vida > 0){
                
                     // GETAXIS
                     float H = Input.GetAxis("Horizontal")*Speed;       
                     H *= Time.deltaTime;
                      transform.Translate (H,0,0);

                 //Controles
//SALTANDO
                 if(Input.GetKey(KeyCode.Space) && ActivaSalto == true){
                    GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,Salto), ForceMode2D.Impulse);
                    ActivaSalto = false;
                    controlAnimacion.SetBool("saltar", true);
                    
                    //controlAnimacion.SetBool("cayendo"),

                 }

                 
                
                 
//activa camina controles
                 if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ){
                    transform.localScale = new Vector3 (1,1,1);
                    controlAnimacion.SetBool("activacamina",true);


                
                     direccionBala = true;
                     ParardireccionBala = true;                                                                                    
                     paralax.DireccionPersonaje = "derecha";

                 }


                 if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ){
                    transform.localScale = new Vector3 (-1,1,1);
                    controlAnimacion.SetBool("activacamina",true);
                    
                     direccionBala = false;                  
                     paralax.DireccionPersonaje = "izquierda";
                        
                 }

                  if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) ){
                    transform.localScale = new Vector3 (1,1,1);
                    controlAnimacion.SetBool("activacamina",false);

                    ParardireccionBala = false;
                    paralax.DireccionPersonaje = "parado";
                 }
                 if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) ){
                    transform.localScale = new Vector3 (-1,1,1);
                    controlAnimacion.SetBool("activacamina",false);

                    ParardireccionBala = true;
                    paralax.DireccionPersonaje = "parado";
                    
                 }

                
        }//final de vida


   
    }//fin Update


    void OnCollisionEnter2D(){

        ActivaSalto = true;

// para activar salto que vuelva a pasivo y en saltando que sea false
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        clonBalaEnemigo = col.gameObject.name;  // Ottiene il nome dell'oggetto che ha causato la collisione

        if (clonBalaEnemigo == "Personaje")
        {
            // Decrementa la vita del personaggio principale (presumibilmente presente in principalScript)
            principalScript.Vida--;
            

            //gestorSonido.GetComponent<audioManager>().sonidoDead();  // Riproduce un suono di morte usando l'audioManager
            
        }
        if (col.CompareTag("Enemy"))
    {
        StartCoroutine(ChangeColorTemporarily());
          // Avvia la coroutine solo se l'oggetto ha il tag "enemy"
          principalScript.Vida--;
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




