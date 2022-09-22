using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class TimeAnswer : MonoBehaviour
{
    [SerializeField] public GameObject Displacement;
    [SerializeField] public GameObject InitialVelocity;
    [SerializeField] public GameObject FinalVelocity;
    [SerializeField] public GameObject Acceleration;
    
    public bool DisplacementBool;
    public bool InitialVelocityBool;
    public bool FinalVelocityBool;
    public bool AccelerationBool;
    public bool TimeBool;

    private Image Dis;
    private Image IV;
    private Image FV;
    private Image AC;
    private Image Time;

    private void Start()
    {
        Dis = Displacement.GetComponent<Image>();
        IV = InitialVelocity.GetComponent<Image>();
        FV = FinalVelocity.GetComponent<Image>();
        AC = Acceleration.GetComponent<Image>();
        Time = GetComponent<Image>();
    }

    public void DisplacementPressed()
    {
        DisplacementBool= true;
        AccelerationBool = false;
        InitialVelocityBool = false;
        FinalVelocityBool = false;
        TimeBool = false;
        Dis.color = Color.black;
        IV.color = Color.white;
        FV.color = Color.white;
        AC.color = Color.white;
        Time.color = Color.white;
    }
    public void InitialVelocityPressed()
    {
        InitialVelocityBool = true;
        DisplacementBool = false;
        FinalVelocityBool = false;
        AccelerationBool = false;
        TimeBool = false;
        Dis.color = Color.white;
        IV.color = Color.black;
        FV.color = Color.white;
        AC.color = Color.white;
        Time.color = Color.white;
    }
    public void FinalVelocityPressed()
    {
        FinalVelocityBool = true;
        InitialVelocityBool = false;
        DisplacementBool = false;
        AccelerationBool = false;
        TimeBool = false;
        Dis.color = Color.white;
        IV.color = Color.white;
        FV.color = Color.black;
        AC.color = Color.white;
        Time.color = Color.white;
    }
    public void AccelerationPressed()
    {
        AccelerationBool = true;
        InitialVelocityBool = false;
        FinalVelocityBool = false;
        DisplacementBool = false;
        TimeBool = false;
        Dis.color = Color.white;
        IV.color = Color.white;
        FV.color = Color.white;
        AC.color = Color.black;
        Time.color = Color.white;
    }
    public void TimePressed()
    {
        TimeBool = true;
        InitialVelocityBool = false;
        FinalVelocityBool = false;
        AccelerationBool = false;
        DisplacementBool = false;
        Dis.color = Color.white;
        IV.color = Color.white;
        FV.color = Color.white;
        AC.color = Color.white;
        Time.color = Color.black;
    }
}
