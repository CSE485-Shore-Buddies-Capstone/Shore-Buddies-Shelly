using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHandler : MonoBehaviour
{
    public GameObject stepsHolder;
    public Button lastStepButton;
    public Button nextStepButton;
    public int currentStep;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = 0;
        lastStepButton.onClick.AddListener(LastStep);
        nextStepButton.onClick.AddListener(NextStep);
    }

    void LastStep(){
        GameObject previousStepChild = stepsHolder.transform.GetChild(currentStep).gameObject;
        previousStepChild.SetActive(false);

        if(currentStep == 0){
            currentStep = stepsHolder.transform.childCount-1;
        }else{
            currentStep -= 1;
            lastStepButton.gameObject.SetActive(true);
        }
        
        GameObject currentStepChild = stepsHolder.transform.GetChild(currentStep).gameObject;
        currentStepChild.SetActive(true);
    }

    void NextStep(){
        GameObject previousStepChild = stepsHolder.transform.GetChild(currentStep).gameObject;
        previousStepChild.SetActive(false);

        if(currentStep == stepsHolder.transform.childCount-1){
            currentStep = 0;
        }else{
            currentStep += 1;
            lastStepButton.gameObject.SetActive(true);
        }
        
        GameObject currentStepChild = stepsHolder.transform.GetChild(currentStep).gameObject;
        currentStepChild.SetActive(true);
    }
}
