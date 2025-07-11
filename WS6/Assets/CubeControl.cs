using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeControl : MonoBehaviour
{
    public GameObject _go; // NEW LINE
    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void StartButton(){
        _rb.useGravity= true;
        _go.SetActive(true); // NEW LINE
    }


    public void StopButton(){
        _rb.useGravity= true;
    }


    public void ChangeColorButton(){
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
