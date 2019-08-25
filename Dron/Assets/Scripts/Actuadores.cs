using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuadores : MonoBehaviour
{
    private Rigidbody rb;
    private float upForce; // fuerzaElevacion
    private float movementForwardSpeed = 250.0f;
    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;
    private float sideMovementAmount = 250.0f;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public void Ascender(){
        upForce = 190;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Descender(){
        upForce = 10;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Flotar(){
        upForce = 98.1f;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    public void Adelante(){
        rb.AddRelativeForce(Vector3.forward * movementForwardSpeed);
    }

    public void Atras(){
        rb.AddRelativeForce(Vector3.forward * -movementForwardSpeed);
    }

    public void GirarDerecha(){
        wantedYRotation += rotateAmountByKeys;
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
        rb.rotation = Quaternion.Euler(new Vector3(rb.rotation.x, currentYRotation, rb.rotation.z));
    }

    public void GirarIzquierda(){
        wantedYRotation -= rotateAmountByKeys;
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
        rb.rotation = Quaternion.Euler(new Vector3(rb.rotation.x, currentYRotation, rb.rotation.z));
    }

    public void Derecha(){
        rb.AddRelativeForce(Vector3.right * sideMovementAmount);
    }

    public void Izquierda(){
        rb.AddRelativeForce(Vector3.right * -sideMovementAmount);
    }

    public void VHSpeed1(){
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Mathf.Lerp(rb.velocity.magnitude, 1.0f, Time.deltaTime *10f));
    }
    public void VHSpeed2(){
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Mathf.Lerp(rb.velocity.magnitude, 1.0f, Time.deltaTime *10f));
    }

    private Vector3 velocitysmooth;
    public void VHSpeed3(){
        rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.zero, ref velocitysmooth, 0.15f);
    }
    private float currentSideWay;
    private float tillVelocity;
    
    //Sideways
    public void swerwe1(){
        rb.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
        currentSideWay = Mathf.SmoothDamp(currentSideWay, 20 * Input.GetAxis("Horizontal"), ref tillVelocity, 0.1f);
    }

    public void swerwe0(){
        currentSideWay = Mathf.SmoothDamp(currentSideWay, 0,ref tillVelocity, 0.1f);
    }

}

