using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDissabler : MonoBehaviour {
    public bool trapDissabler = false;
    [SerializeField]private GameObject _trapDissableObject;
    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ik Werk ook weer");
        if (other.tag == "TrapDissabler")
        {
            trapDissabler = true;
            
        }
        else
        {
            trapDissabler = false;
        }
    }
    private void Update()
    {
        if (trapDissabler)
        {
            Destroy(_trapDissableObject);
            Destroy(gameObject);
            
        }
    }
}
