using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform objectToRotate;

    void Update()
    {
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation,mainCam.transform.rotation,3f);
    }
}
