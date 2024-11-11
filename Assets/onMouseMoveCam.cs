using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class onMouseMoveCam : MonoBehaviour
{
    [SerializeField] private Vector3 mouseMove;
    [SerializeField] private Transform targetRotate;
    void Update()
    {
        mouseMove.y = Input.GetAxis("Mouse Y");
        mouseMove.x = Input.GetAxis("Mouse X");

        targetRotate.rotation = Quaternion.Euler(0, + mouseMove.x, 0);
    }
}
