using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChecker : MonoBehaviour {
    private TrapActive _activateTrap;
    public bool activate = false;
    private ParticleTrap _particleTrap;
    private void Start()
    {
        _activateTrap = GetComponent<TrapActive>();
        _particleTrap = GetComponent<ParticleTrap>();
    }

    private void OnTriggerEnter(Collider collision){
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player") {
            activate = true;
            Destroy(gameObject);
            Debug.Log(activate);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("has no collision");
            activate = false;
        }
    }
    private void Update()
    {
        print(activate);
    }
}
