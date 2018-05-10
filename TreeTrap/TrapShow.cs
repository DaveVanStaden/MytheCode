using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShow : MonoBehaviour {
    public GameObject bearTrap;
    public GameObject trapActivator;
    private TrapActive _trapActive;
    // Use this for initialization
    void Start()
    {
        _trapActive = trapActivator.GetComponent<TrapActive>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_trapActive.activateTrap)
        {
            bearTrap.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
