using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {
    /* We zijn ons bewust van de lelijkheid van 4 dezelfde scripts
     * Maar door tijdnood waren we genoodzaakt dit te doen.
     * Sorry voor het ongemak
     */
    private float _x;
    private float _y;
    public float speed = 5;
    private float _horizontalInput;
    private float vertical;
    private float horizontal;
    private string stickY;
    private string stickX;

    private void Start()
    {
        if (stickY == null)
            stickY = Controller.LeftStickYP1;
        if (stickX == null)
            stickX = Controller.LeftStickXP1; 
    }
    void Update () {
        vertical = Input.GetAxis(stickY) * speed;
        horizontal = Input.GetAxis(stickX) * speed;
    }
    void FixedUpdate(){
        vertical *= speed * Time.deltaTime;
        horizontal *= speed * Time.deltaTime;
        transform.Translate(-horizontal, -vertical, 0);
    }
}
