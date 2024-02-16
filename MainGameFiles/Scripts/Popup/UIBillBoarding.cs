using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillBoarding : MonoBehaviour
{
    private Camera cam;

    // Update is called once per frame
    void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        transform.forward = cam.transform.forward; 
    }

}
