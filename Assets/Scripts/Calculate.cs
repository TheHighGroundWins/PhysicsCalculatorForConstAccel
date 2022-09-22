using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    [SerializeField] private GameObject DisplacementToggleGameObject;
    [SerializeField] private GameObject VIToggleGameObject;
    [SerializeField] private GameObject VFToggleGameObject;
    [SerializeField] private GameObject ACToggleGameObject;
    [SerializeField] private GameObject TimeToggleGameObject;
    
    [SerializeField] GameObject DisplacementTextMeshProGameObject;
    [SerializeField] GameObject VITextMeshProGameObject;
    [SerializeField] GameObject VFTextMeshProGameObject;
    [SerializeField] GameObject ACTextMeshProGameObject;
    [SerializeField] GameObject TimeTextMeshProGameObject;

    [SerializeField] private GameObject answerBoxGameObject;

    [SerializeField] private GameObject timeAnswerGameObject;

    private TimeAnswer timeAnswer;
    
    //text properties
    Toggle DisplacementToggle;
    Toggle VIToggle;
    Toggle VFToggle;
    Toggle ACToggle;
    Toggle TimeToggle;
    
    TMP_InputField DisplacementTextMeshPro;
    TMP_InputField VITextMeshPro;
    TMP_InputField VFTextMeshPro;
    TMP_InputField ACTextMeshPro;
    TMP_InputField timeTextMeshPro;

    TMP_InputField Answer;

    private double DIS;
    private double VI;
    private double VF;
    private double AC;
    private double TIME;

    private void Start()
    {
        DisplacementToggle = DisplacementToggleGameObject.GetComponent<Toggle>();
        VIToggle = VIToggleGameObject.GetComponent<Toggle>();
        VFToggle = VFToggleGameObject.GetComponent<Toggle>();
        ACToggle = ACToggleGameObject.GetComponent<Toggle>();
        TimeToggle = TimeToggleGameObject.GetComponent<Toggle>();

        DisplacementTextMeshPro = DisplacementTextMeshProGameObject.GetComponent<TMP_InputField>();
        VITextMeshPro = VITextMeshProGameObject.GetComponent<TMP_InputField>();
        VFTextMeshPro = VFTextMeshProGameObject.GetComponent<TMP_InputField>();
        ACTextMeshPro = ACTextMeshProGameObject.GetComponent<TMP_InputField>();
        timeTextMeshPro = TimeTextMeshProGameObject.GetComponent<TMP_InputField>();

        Answer = answerBoxGameObject.GetComponent<TMP_InputField>();
        timeAnswer = timeAnswerGameObject.GetComponent<TimeAnswer>();
    }

    public void OnClick()
    {

        if (DisplacementToggle.isOn)
            DIS = Double.Parse(DisplacementTextMeshPro.text);
        if(VIToggle.isOn)
            VI = Double.Parse(VITextMeshPro.text);
        if (VFToggle.isOn)
            VF = Double.Parse(VFTextMeshPro.text);
        if(ACToggle.isOn)
            AC = Double.Parse(ACTextMeshPro.text);
        if(TimeToggle.isOn)
        TIME = Double.Parse(timeTextMeshPro.text);
        
        //for displacement
        if (timeAnswer.DisplacementBool)
        {
            //if everything is ticked
            if (DisplacementToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && ACToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VI*TIME+0.5*AC*Squared(TIME)).ToString();
            }
            
            if (VIToggle.isOn && ACToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VI*TIME+0.5*AC*Squared(TIME)).ToString();
            }
            
            if (VIToggle.isOn && TimeToggle.isOn && ACToggle.isOn)
            {
                Answer.text = ((Squared(VF)-Squared(VI))/(2*AC)).ToString();
            }

            if (VIToggle.isOn && VFToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (0.5*(VI+VF)*TIME).ToString();
            }

            if (VFToggle.isOn&&TimeToggle.isOn&&ACToggle.isOn)
            {
                Answer.text = (VF*TIME-0.5*AC*Squared(TIME)).ToString();
            }
        }
        
        //for initial velocity
        if (timeAnswer.InitialVelocityBool)
        {
            //if everything is ticked
            if (DisplacementToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && ACToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VF - AC * TIME).ToString();
            }
            
            
        }


        //for final velocity
        //for acceleration
        //for time
    }

    double Squared(double number)
    {
        return (double)(Mathf.Pow((float)number,2));
    }

    double SquareRoot(double number)
    {
        return (double)(Mathf.Sqrt((float)number));
    }
}
