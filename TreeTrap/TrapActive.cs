using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActive : MonoBehaviour {
    public bool activateTrap = false;
    private MeshRenderer mesh;
    private BoxCollider box;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log(activateTrap + " " + other.tag);
        if (other.tag == "TrapActivator"){
            activateTrap = true;
            mesh.enabled = false;
            box.enabled = false;
        } else{
            activateTrap = false;
        }

    }
}
