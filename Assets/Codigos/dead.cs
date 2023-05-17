using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{
    public Movimiento Personaje;
    private audioManager gestorSonido;


    private void Awake() {
    gestorSonido = audioManager.Instance;
    Personaje = Movimiento.Instance;



    }


    //private static int contadorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //contadorTrigger = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(contadorTrigger);
        
    }

    void OnTriggerEnter2D(){
        Debug.Log("HAS MUERTO!!!!!");
        //gestorSonido.GetComponent<AudioSource>().PlayOneShot(gestorSonido.GetComponent<audioManager>().sonidoMuerte,1f);
        gestorSonido.GetComponent<audioManager>().sonidoDead();
        principalScript.Vida--;
        Personaje.transform.position = new Vector2 (-1.18f,1.44f);

        }





}
