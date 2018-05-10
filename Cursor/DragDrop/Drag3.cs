using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3 : MonoBehaviour {
    /* We zijn ons bewust van de lelijkheid van 4 dezelfde scripts
 * Maar door tijdnood waren we genoodzaakt dit te doen.
 * Sorry voor het ongemak
 * Dit script is via PairProgramming gemaakt
 */
    private string xButton;
    private RaycastHit hit;
    private RaycastHit hit2;
    private LayerMask _mask = 1 << 10;
    private Vector3 _floorPosition;
    private bool _isPickedUp;

    void Start()
    {
        xButton = Controller.Cross3;
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, (transform.position - Camera.main.transform.position));
        if (Physics.Raycast(ray, out hit2, _mask))
        {
            _floorPosition = hit2.point;
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Drag" || hit.collider.gameObject.tag == "TrapActivator" || hit.collider.gameObject.tag == "TrapDissabler")
            {
                if (Input.GetButton(xButton))
                {
                    hit.collider.gameObject.transform.position = new Vector3(_floorPosition.x, -9, _floorPosition.z);
                }

            }
        }
    }
}
