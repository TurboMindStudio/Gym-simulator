using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showItem : MonoBehaviour
{
    public Transform cam;
    public float distance;
    public LayerMask layerMask;
    private Ray ray;
    private RaycastHit hit;
   // public Outline[] outline;
    private void Update()
    {
        ray=new Ray(cam.transform.position,cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward*distance,Color.green);
        if(Physics.Raycast(ray,out hit, distance, layerMask))
        {
            if (hit.collider.CompareTag("equipment"))
            {
               
                hit.collider.GetComponent<Outline>().enabled = true;
            }
        }
       
    }
}
