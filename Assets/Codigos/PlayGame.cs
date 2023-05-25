using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayGame : MonoBehaviour
{
    public GameObject CanvasStart;
    public GameObject CanvasCotroles;



    // Start is called before the first frame update
    void Start()
    {
        CanvasCotroles.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EntrarJuego(){
    SceneManager.LoadScene("Nivel1");
}
    public void MostrarControles(){
        CanvasStart.SetActive(false);
        CanvasCotroles.SetActive(true);
        
    }

    public void IrStart(){
        CanvasCotroles.SetActive(false);
        CanvasStart.SetActive(true);
        

    }


}

