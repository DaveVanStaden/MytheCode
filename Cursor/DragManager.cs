using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    private bool _isDragged;
    private int _hand = 0;
    private float _pickUpCooldown = 3;
    [SerializeField]
    private Material _material;
    private Material _defaultMaterial;
    private Vector3 _hitFloor;
    private bool _isMouseDown = false;
    // Use this for initialization
    void Start()
    {
        Collider objCollider = this.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log (_hand);
        Ray ray = new Ray(Camera.main.transform.position, (transform.position - Camera.main.transform.position));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _hitFloor = hit.collider.transform.position;
            if (hit.collider.gameObject.tag == "Drag" && Input.GetKeyDown("e") || hit.collider.gameObject.tag == "TrapActivator" && Input.GetKeyDown("e") 
                || hit.collider.gameObject.tag == "TrapDissabler" && Input.GetKeyDown("e"))
            {
                Rigidbody _rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                _hand = _hand + 1;
                _isDragged = true;
                if (_hand == 1 && _isDragged == true)
                {
                    _pickUpCooldown -= Time.deltaTime;
                    hit.collider.gameObject.transform.parent = this.transform;
                    hit.collider.gameObject.transform.position = transform.position;
                    _defaultMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;
                    hit.collider.gameObject.GetComponent<Renderer>().material = _material;
                    //Physics.IgnoreCollision(hit.collider, this.GetComponent<Collider>(), true);
                    _rb.useGravity = false;
                    if (_hand == 1 && Input.GetKeyDown("e") && _pickUpCooldown < 0 && _isDragged == true)
                    {
                        _hand = 1 - 1;
                        _isDragged = false;
                    }
                }
                else if (_hand != 1)
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material = _defaultMaterial;
                    //Physics.IgnoreCollision(hit.collider, this.GetComponent<Collider>(), false);
                    _rb.useGravity = true;
                    hit.collider.gameObject.transform.parent = null;
                    hit.collider.gameObject.transform.position = _hitFloor;
                    //hit.collider.gameObject.transform.position.z = this.transform.position.z * 10;
                    _isDragged = false;
                }
                if (_hand == 1 && Input.GetKeyDown("e") && _isDragged == true || _hand > 1)
                {
                    _hand = 0 - 1;
                    _isDragged = false;
                }
            }
        }
    }
}







/*private void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag == "Drag")
    {
        Debug.Log("Collide");
        if (Input.GetKey("e"))
        {
            Debug.Log("it works");
            collision.transform.position = transform.position;
            collision.gameObject.transform.parent = this.transform;
            hand = hand + 1;
            if(hand == 1)
            {
                Debug.Log(PickUpCooldown);
                transform.position = collision.gameObject.transform.position;
                if (hand == 1 && Input.GetKey("e") && PickUpCooldown >= 5f)
                {
                    hand = hand - 1;
                    collision.gameObject.transform.parent = null;
                }


            }


        }

    }
    */



