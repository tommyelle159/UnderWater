using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAudio : MonoBehaviour
{
    public GameObject Personaje;
    private audioManager gestorSonido;
    private static int  contadorTrigger;
    //private AudioSource emisorArea;


    private void Awake() {
    gestorSonido = audioManager.Instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        contadorTrigger = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(contadorTrigger);
        
    }

    void OnTriggerEnter2D(){
        if(contadorTrigger <=0){

            gestorSonido.GetComponent<audioManager>().sonidoFxPozo();
            Debug.Log("EfectoEco!!!");
            contadorTrigger++;
            gestorSonido.GetComponent<audioManager>().sonidoDead();
            
        } else if( contadorTrigger >=0){
            gestorSonido.GetComponent<audioManager>().sonidoFxIdlle();

        }

    }//fine TriggerEnter2d

    void OnTriggerExit2D(){
        contadorTrigger--;
        
            gestorSonido.GetComponent<audioManager>().sonidoFxIdlle();
    }


}
