using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    private Actuadores actuador;
    private Sensores sensor;

    void Start(){
        actuador = GetComponent<Actuadores>();
        sensor = GetComponent<Sensores>();
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.I))
            actuador.Ascender();
        if(Input.GetKey(KeyCode.K))
            actuador.Descender();
        if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
            actuador.Flotar();

        if(Input.GetAxis("Vertical") > 0)
            actuador.Adelante();
        if(Input.GetAxis("Vertical") < 0)
            actuador.Atras();

        if(Input.GetKey(KeyCode.J))
            actuador.GirarIzquierda();
        if(Input.GetKey(KeyCode.L))
            actuador.GirarDerecha();

        if(Input.GetAxis("Horizontal") > 0)
            actuador.Derecha();
        if(Input.GetAxis("Horizontal") < 0)
            actuador.Izquierda();


        if(sensor.TocandoBasura())
            Debug.Log("Tocando basura!");
        if(sensor.TocandoPared())
            Debug.Log("Tocando pared!");

            // Manejo de velocidades
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && (Input.GetAxis("Horizontal")) > 0.2f){
        	actuador.VHSpeed1();
        	Debug.Log("uno");

        }
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && (Input.GetAxis("Horizontal")) < 0.2f){
        	actuador.VHSpeed1();
        	Debug.Log("dos");
        }
        if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && (Input.GetAxis("Horizontal")) > 0.2f){
        	actuador.VHSpeed2();
        	Debug.Log("tres");
        }
        if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && (Input.GetAxis("Horizontal")) < 0.2f){
        	actuador.VHSpeed3();
        	Debug.Log("Mantener");
        }
        //Sideways
        if(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f){
        	actuador.swerwe1();
        }else{
        	actuador.swerwe0();
        }
    }
}
