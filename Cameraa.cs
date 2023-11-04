using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float rotationsens = 0.1f;
    public float smoothtime = 0.12f;
    public bool enablemobilinputs = false;
    public LayerMask wallLayer;
    public float rotationmin = -6f;
    public float rotationmax = 80f;
    public Transform target;
    Vector3 targetrot;
    Vector3 currentvel;
    public FixedTouchField touchField;
    public GameObject player;
    public float distanceplayer = 16f;
    public float height = 2;
    private float currentDistance;
    private float desiredDistance;
    private float correctedDistance;
    private float rotationX = 0f;
    private RaycastHit hit;
    public bool isMoving = false;
  
 

    void Start()
    {

        target = player.transform;
        
        currentDistance = distanceplayer;
        desiredDistance = distanceplayer;
        correctedDistance = distanceplayer;

        
        rotationX = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
         transform.LookAt(target.transform.position);
        if (player.GetComponent<Player>().hareket)
        {
            isMoving = true;
            if (isMoving)
            {
                Yaxis = transform.eulerAngles.y;
                Xaxis = 10;
                isMoving = false;
            }
         
       

        }

       
        else
        {
            isMoving = false;
            Yaxis += touchField.TouchDist.x * rotationsens;
            Xaxis -= touchField.TouchDist.y * rotationsens;
            Xaxis = Mathf.Clamp(Xaxis, rotationmin, rotationmax);
            targetrot = Vector3.SmoothDamp(targetrot, new Vector3(Xaxis, Yaxis), ref currentvel, smoothtime);
            transform.eulerAngles = targetrot;
         

        }
        Quaternion rotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0);
        transform.position = target.position - rotation * Vector3.forward * currentDistance;
        Vector3 targetPosition = target.position - rotation * Vector3.forward * currentDistance;
        if (Physics.Linecast(target.position, targetPosition, out hit, wallLayer))
        {
            correctedDistance = Vector3.Distance(target.position, hit.point) - 0.2f;
        }
        else
        {
            correctedDistance = currentDistance;
        }
        transform.position = target.position - rotation * Vector3.forward * correctedDistance;
        
    }
}
