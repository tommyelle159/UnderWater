using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoPersonaje : MonoBehaviour
{
    public GameObject bala;

    //private audioManager gestorSonido;

    

    private void Awake() {
    //gestorSonido = audioManager.Instance;
    }


    void Setup(){
        
        




    } // fin Setup

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) == true){
             Instantiate (bala,new Vector2(transform.position.x, transform.position.y), transform.rotation);
             //this.GetComponentInParent<AudioSource>().PlayOneShot(gestorSonido.GetComponent<audioManager>().lanzaBola, 1f);

        }
    }
}