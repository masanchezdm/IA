using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensores : MonoBehaviour
{
    private bool tocandoPared;
    // private bool cercaPared;
    private bool tocandoBasura;
    // private bool cercaBasura;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            tocandoBasura = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            tocandoBasura = false;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Pared")){
            tocandoPared = true;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Pared")){
            tocandoPared = false;
        }
    }

    public bool TocandoPared(){
        return tocandoPared;
    }

    public bool TocandoBasura(){
        return tocandoBasura;
    }
}
