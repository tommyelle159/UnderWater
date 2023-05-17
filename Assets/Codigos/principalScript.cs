using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class principalScript : MonoBehaviour
{
    public static int Score =0;
    public static int Vida = 3;
    public int currentLives;
    public static int Enemigos = 0;
    public GUISkin miSkin;
    int Anchopantalla;
    public Texture2D logoJuego;
    
        private static principalScript instance;
        public static principalScript Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<principalScript>();
                if (instance == null) {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<principalScript>();
                    singleton.name = typeof(principalScript).ToString() + " (Singleton)";
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

    

   

    
    
    

    /*void Awake(){
       DontDestroyOnLoad(gameObject);
    }*/
    



    // Start is called before the first frame update
    void Start()
    {
        
        currentLives = Vida;
        
        

    }

    // Update is called once per frame
    void Update()
    {
         Anchopantalla = Screen.width/2;

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
       }

        if(Vida <= 0){
            SceneManager.LoadScene("GameOver");
            Vida = 3;
            

        }

    

        
        
        
       // Debug.Log("Vida "+Vida);
        //Debug.Log("Score "+Score);
       // Debug.Log("Enemigos "+Enemigos);
       
        
    }

    

    void OnGUI(){


        //GUI.Label(new Rect(20, 20, 150, 80),"HOLA");
        //GUI.Label(new Rect(20, 20, 150, 80),"Vida: "+Vida.ToString());

        if (SceneManager.GetActiveScene().name == "Nivel1"){
            GUI.skin = miSkin;
        GUI.Label(new Rect(20, 40, 150, 80),"Vida: "+Vida.ToString(),"estiloScore");
        GUI.Label(new Rect(220, 40, 150, 80),"Enemigos: "+Enemigos.ToString(),"estiloScore");
        GUI.Label(new Rect(520, 40, 150, 80),"Score: "+Score.ToString(),"estiloScore");
        GUI.Label(new Rect(Anchopantalla-100, 20, 150, 80),"SKULL'S GARDEN", "estiloTitulo");
        //GUI.Label(new Rect(Anchopantalla -120, 20, 150, 80),"SKULL GARDEN", "estiloTitulo");

        //Imagen
        //GUI.DrawTexture(new Rect(Screen.width-200,20,80,80),logoJuego);
        GUI.DrawTexture(new Rect(Screen.width-200,40,128,128),logoJuego);

        }

        if (SceneManager.GetActiveScene().name == "GameOver"){
            GUI.skin = miSkin;
            
        GUI.Label(new Rect(220, 40, 150, 80),"Enemigos: "+Enemigos.ToString(),"estiloScore");
        GUI.Label(new Rect(520, 40, 150, 80),"Score: "+Score.ToString(),"estiloScore");
        GUI.Label(new Rect(Anchopantalla-100, 20, 150, 80),"SKULL'S GARDEN", "estiloTitulo");
        //GUI.Label(new Rect(Anchopantalla -120, 20, 150, 80),"SKULL GARDEN", "estiloTitulo");

        //Imagen
        //GUI.DrawTexture(new Rect(Screen.width-200,20,80,80),logoJuego);
        GUI.DrawTexture(new Rect(Screen.width-200,40,128,128),logoJuego);
        }


        if (SceneManager.GetActiveScene().name == "start"){
            Score =0;
            Enemigos = 0;

            


        }
        
        
        
    }

    

    


}

        


    


    
    
    
        



