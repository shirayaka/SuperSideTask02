using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    [SerializeField] private Transform mainParent;
    [SerializeField] private Transform targetChild;

    [SerializeField] private Vector3 mouseMove;


    [SerializeField] private float yValue;

    [SerializeField] private float yRTValue;


 
    void Start()
        {
            
        }
    void Update()
    {
        //mouseMove.y = Input.GetAxis("Mouse Y");
        //yRTValue = Input.GetAxis("Mouse X");


        targetChild.position = new Vector3(mainParent.position.x, yValue, mainParent.position.z);
        //targetChild.rotation = Quaternion.Euler(0, + mouseMove.x, 0);
    }

    /*void LateUpdate()
    {
        if (targetChild)
        {
            if (Input.GetMouseButton(2))
            {
                targetx += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f * (5 / (distance + 2));
                targety -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            targety = ClampAngle(targety, yMinLimit, yMaxLimit);

            x = Mathf.LerpAngle(x, targetx,0.1f);
            y = Mathf.LerpAngle(y, targety, 1f);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            targetdistance = Mathf.Clamp(targetdistance - (Input.GetAxis("Mouse ScrollWheel") *  ScrollSensativity ), distanceMin, distanceMax);
            distance = Mathf.Lerp(distance, targetdistance, 0.1f); //Smooth

            RaycastHit hit;
            if (Physics.Linecast(targetChild.position, transform.position, out hit))
            {
                targetdistance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + targetChild.position;

            transform.rotation = rotation;

            transform.position = position;
        }
    }*/


    
}
