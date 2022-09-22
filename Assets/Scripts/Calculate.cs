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
    Toggle DisToggle;
    Toggle VIToggle;
    Toggle VFToggle;
    Toggle AToggle;
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
    private double A;
    private double TIME;

    private void Start()
    {
        DisToggle = DisplacementToggleGameObject.GetComponent<Toggle>();
        VIToggle = VIToggleGameObject.GetComponent<Toggle>();
        VFToggle = VFToggleGameObject.GetComponent<Toggle>();
        AToggle = ACToggleGameObject.GetComponent<Toggle>();
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

        if (DisToggle.isOn)
            DIS = Double.Parse(DisplacementTextMeshPro.text);
        if(VIToggle.isOn)
            VI = Double.Parse(VITextMeshPro.text);
        if (VFToggle.isOn)
            VF = Double.Parse(VFTextMeshPro.text);
        if(AToggle.isOn)
            A = Double.Parse(ACTextMeshPro.text);
        if(TimeToggle.isOn)
        TIME = Double.Parse(timeTextMeshPro.text);
        
        //for displacement
        if (timeAnswer.DisplacementBool)
        {
            //if everything is ticked
            if (DisToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VI*TIME+0.5*A*Square(TIME)).ToString();
            }
            
            if (VIToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VI*TIME+0.5*A*Square(TIME)).ToString();
            }
            
            if (VIToggle.isOn && TimeToggle.isOn && AToggle.isOn)
            {
                Answer.text = ((Square(VF)-Square(VI))/(2*A)).ToString();
            }

            if (VIToggle.isOn && VFToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (0.5*(VI+VF)*TIME).ToString();
            }

            if (VFToggle.isOn&&TimeToggle.isOn&&AToggle.isOn)
            {
                Answer.text = (VF*TIME-0.5*A*Square(TIME)).ToString();
            }
        }
        
        //for initial velocity
        if (timeAnswer.InitialVelocityBool)
        {
            //if everything is ticked
            if (DisToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VF - A * TIME).ToString();
            }

            if (VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VF - A * TIME).ToString();
            }

            if (DisToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text=((DIS-0.5*A*Square(TIME))/TIME).ToString();
            }

            if (VFToggle.isOn && AToggle.isOn && DisToggle.isOn)
            {
                Answer.text = (SquareRoot(Square(VF)-2*A*DIS)).ToString();
            }

            if (DisToggle.isOn && TimeToggle.isOn && VFToggle.isOn)
            {
                Answer.text = ((2*VF)/TIME-VF).ToString();
            }
        }

        
        //for final velocity
        if (timeAnswer.FinalVelocityBool)
        {
            //if everything is ticked
            if (DisToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VF+A*TIME).ToString();
            }

            if (VIToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = (VF+A*TIME).ToString();
            }

            if (VIToggle.isOn && DisToggle.isOn && AToggle.isOn)
            {
                Answer.text = (SquareRoot(Square(VI)+2*A*DIS)).ToString();
            }

            if (VIToggle.isOn && DisToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((2*DIS)/TIME-VI).ToString();
            }

            if (DisToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((DIS+0.5*A*Square(TIME))/TIME).ToString();
            }
            
        }
        
        //for acceleration
        if (timeAnswer.AccelerationBool)
        {
            //if everything is ticked
            if (DisToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((VF-VI)/TIME).ToString();
            }

            if (VFToggle.isOn && VIToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((VF-VI)/TIME).ToString();
            }

            if (DisToggle.isOn && VIToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((2*(DIS-VI*TIME))/Square(TIME)).ToString();
            }

            if (VFToggle && VIToggle && DisToggle.isOn)
            {
                Answer.text = ((Square(VF)-Square(VI))/2*DIS).ToString();
            }

            if (DisToggle.isOn && VFToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((2*(DIS-VF*TIME))/Square(TIME)).ToString();
            }
        }
        
        //for time
        if (timeAnswer.TimeBool)
        {
            //if everything is ticked
            if (DisToggle.isOn && VIToggle.isOn &&
                VFToggle.isOn && AToggle.isOn && TimeToggle.isOn)
            {
                Answer.text = ((VF-VI)/A).ToString();
            }

            if (VFToggle.isOn && VIToggle.isOn && AToggle.isOn)
            {
                Answer.text = ((VF-VI)/A).ToString();
            }

            if (VIToggle.isOn && AToggle.isOn && DisToggle.isOn)
            {
                Answer.text = (-VI+((SquareRoot(Square(VI)-4*0.5*A*-DIS))/2*0.5*A)).ToString();
            }

            if (VFToggle.isOn && AToggle.isOn && DisToggle.isOn)
            {
                Answer.text = (-VF+((SquareRoot(Square(VF)-4*0.5*A*-DIS))/2*-0.5*A)).ToString();
            }

            if (DisToggle.isOn && VIToggle.isOn && VFToggle.isOn)
            {
                Answer.text = ((2*DIS)/(VI+VF)).ToString();
            }
        }
    }

    double Square(double number)
    {
        return (double)(Mathf.Pow((float)number,2));
    }

    double SquareRoot(double number)
    {
        return (double)(Mathf.Sqrt((float)number));
    }
}
