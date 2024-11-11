using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : MonoBehaviour
{
    [SerializeField] private Image StaminaBar;
    [SerializeField] private moveman moveman;
    [SerializeField] private GameObject staminaUI;
    public float Stamina, MaxStamina;
    public float RunningCost;
    public float rechargeStamina;
    public bool isRun;
    //public bool startCharge = false;

    //private IEnumerator startRecharge;


    private void Start() 
    {
        //startRecharge = rechargeBehaviour();
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRun = false;
        }*/
        if (isRun)
        {
            staminaUI.SetActive(true);
            Stamina -= RunningCost * Time.deltaTime;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
        if (isRun == false)
        {
            Stamina += rechargeStamina * Time.deltaTime;
            if (Stamina > 100) Stamina = 100;
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
        if (Stamina == 100)
        {
            staminaUI.SetActive(false);
        }
    }

    /*IEnumerator rechargeBehaviour()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Coroutine Start!");
        startCharge = true;
    }*/
}
