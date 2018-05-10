using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInBox : MonoBehaviour {
	void Update () {
        CheckPosition();
    }
    void CheckPosition(){
        // X axis
        if (transform.position.x <= 120f){
            transform.position = new Vector3(120, 29, transform.position.z);
        }
        else if (transform.position.x >= 150f){
            transform.position = new Vector3(150f, 29, transform.position.z);
        }
        // Y axis
        if (transform.position.z <= 90f){
            transform.position = new Vector3(transform.position.x, 29, 90f);
        }
        else if (transform.position.z >= 102f){
            transform.position = new Vector3(transform.position.x, 29, 102f);
        }
    }
}
