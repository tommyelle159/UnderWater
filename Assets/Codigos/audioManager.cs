using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public AudioClip bandaSonora;
    public AudioClip ClicMenu;
    public AudioClip lanzaBola;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoGoal;
    public AudioClip sonidoBola;

    
    

    private AudioSource hiloMusical;
    private Scene escenaActual;

    public AudioMixerSnapshot efectoNormal;
    public AudioMixerSnapshot efectoArea;

    public static GameObject scriptDuplicado;
    public GameObject gestorSonido;


    


    /*private void Awake() {
       DontDestroyOnLoad(gameObject);
        gestorSonido = GameObject.Find("AudioManager");

    }*/

        private static audioManager instance;
        //public static audioManager Instance { get { return instance; } }
        
    
    public static audioManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<audioManager>();
                if (instance == null) {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<audioManager>();
                    singleton.name = typeof(audioManager).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }


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


    
    

    

    // Start is called before the first frame update
    void Start()
    {
        hiloMusical = GetComponent<AudioSource>();
        hiloMusical.clip = bandaSonora;
        hiloMusical.loop = true;
        hiloMusical.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        escenaActual = SceneManager.GetActiveScene();
        if(escenaActual.name == "Start"){
            
            hiloMusical.pitch = 0.2f;

        } else if (escenaActual.name == "Nivel1"){
            
            hiloMusical.pitch = 0.75f;
        }else if (escenaActual.name == "GameOver"){
            
            hiloMusical.pitch = 0.4f;
        }                
        
    }


    public void clicBoton(){
            
            hiloMusical.PlayOneShot(ClicMenu, 1f);
            

        }
        public void Volver(){
            
            hiloMusical.PlayOneShot(ClicMenu, 1f);
            

        }

   
   
 public void sonidoPuntos(){
        hiloMusical.PlayOneShot(sonidoGoal,1f);

        }


        public void sonidoDead(){
    if (hiloMusical != null) {
        hiloMusical.PlayOneShot(sonidoMuerte,1f);
    }

    
}


public void sonidoFxIdlle(){
    efectoNormal.TransitionTo(0.1f);

}

public void sonidoFxPozo(){
    efectoArea.TransitionTo(0.1f);
}






}


     




        


