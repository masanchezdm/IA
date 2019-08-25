using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject objectToFollow;
    private bool cercaDeBasura;
    private bool cercaDePared;

    void Update(){
        transform.position = objectToFollow.transform.position;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            cercaDeBasura = true;
            Debug.Log("OnTriggerEnter basura");
        }
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = true;
            Debug.Log("OnTriggerEnter pared");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Basura")){
            cercaDeBasura = false;
            Debug.Log("OnTriggerExit basura");
        }
        if(other.gameObject.CompareTag("Pared")){
            cercaDePared = false;
            Debug.Log("OnTriggerExit pared");
        }
    }

    public bool CercaDeBasura(){
        return cercaDeBasura;
    }

    public bool CercaDePared(){
        return cercaDePared;
    }
}
