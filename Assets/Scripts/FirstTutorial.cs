using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// load first time user status
/// 0 = disabled help
/// 1 = enabled help
/// </summary>
public class FirstTutorial : MonoBehaviour
{
    public GameObject firstHelpPanel;
    void Start()
    {
        // first time playing because player pref was not set, then disable once set
        if(!PlayerPrefs.HasKey("FirstTutorialEnabled")){
            firstHelpPanel.SetActive(true);
            PlayerPrefs.SetInt("FirstTutorialEnabled", 0);
        }else{
            if(PlayerPrefs.GetInt("FirstTutorialEnabled") == 1){
                firstHelpPanel.SetActive(true);
            }else{
                firstHelpPanel.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // uncomment to reset tutorial
        // if(Input.GetKeyDown("i")){
        //     PlayerPrefs.SetInt("FirstTutorialEnabled", 1);
        //     Debug.Log("first time user");
        // }
    }

    public void EnableTutorial(){
        PlayerPrefs.SetInt("FirstTutorialEnabled", 1);
    }

    public void DisableTutorial(){
        PlayerPrefs.SetInt("FirstTutorialEnabled", 0);
    }
}
