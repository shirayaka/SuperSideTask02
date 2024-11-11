using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;

public class lightOnOff : MonoBehaviour
{

    [SerializeField] private GameObject lightComp;
    [SerializeField] private bool toggle;
    [SerializeField] private TwoBoneIKConstraint constraint;

    private float _ikActive = 1.0f;
    private float _ikDeactive = 0f;
    private float constraintWeight = .3f;
    private float currentVelocity = 0;

    //saran zul

    /*public float min = 0f;
    public float max = 1.0f;

    public float FloatUsage;
    float startingValue = 0.0f;*/
    
    // Start is called before the first frame update
    void Start()
    {
        if (toggle == false)
        {
            lightComp.SetActive(false);
        }
        if (toggle == true)
        {
            lightComp.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            if (toggle == false)
            {
                //float constraintWeight = Mathf.SmoothDamp(_ikDeactive, _ikActive, ref currentVelocity, 20);
                //FloatUsage = Mathf.Lerp(min, max, startingValue);
                constraintWeight = Mathf.MoveTowards(_ikActive, _ikDeactive, 20);
                lightComp.SetActive(false);
                constraint.weight = constraintWeight;
            }
            if (toggle == true)
            {
                //float constraintWeight = Mathf.SmoothDamp(_ikActive, _ikDeactive, ref currentVelocity, 20);
                constraintWeight = Mathf.MoveTowards(_ikDeactive, _ikActive, 20);
                //FloatUsage = Mathf.Lerp(min, max, startingValue);
                lightComp.SetActive(true);
                constraint.weight = constraintWeight;
            }
        }
    }
}
