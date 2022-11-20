using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    [Header("Page Transition")]
    public Animator transition;
    public float transitionTime = 4f;
    public GameObject canvas;
    public TMP_Text infoText;
    public TextAsset jsonFile;
    private InfoText infoTextObj;

    void Start(){
        canvas.SetActive(false);
        if (SystemInfo.deviceType == DeviceType.Handheld)
            this.SetVertical();
        else
            this.SetHorizontal();
        
        infoTextObj = InfoText.CreateFromJSON(jsonFile.text);
        infoText.SetText(infoTextObj.options[Random.Range(0, infoTextObj.options.Length)]);
    }

    //will temporarily take in string scene (move onto enum later)
    public void LoadGame(){
        Debug.Log(SystemInfo.deviceType);
        if (SystemInfo.deviceType == DeviceType.Handheld)
            this.Load("FishingGameMobile");
        else
            this.Load("FishingGame");
    }

    //will temporarily take in string scene (move onto enum later)
    public void Load(string scene){
        canvas.SetActive(true);
        StartCoroutine(LoadRoutine(scene));
    }

    private IEnumerator LoadRoutine(string scene){
        // bubbleEffect.SetActive(true);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(scene);
    }

    public void SetVertical(){
        int val_width = Mathf.RoundToInt(Screen.width * (16f/9f));
        int val_height = Mathf.RoundToInt(Screen.height * (9f / 16f));
        Screen.SetResolution(Screen.width, val_width,FullScreenMode.MaximizedWindow,1);
        Screen.SetResolution(val_height, Screen.height, FullScreenMode.MaximizedWindow,1);
    }

    public void SetHorizontal(){
        int val_width = Mathf.RoundToInt(Screen.width * (9f/16f));
        int val_height = Mathf.RoundToInt(Screen.height * (16f / 9f));
        Screen.SetResolution(Screen.width, val_width,FullScreenMode.MaximizedWindow,1);
        Screen.SetResolution(val_height, Screen.height, FullScreenMode.MaximizedWindow,1);
    }

    public void ExitApplication(){
        Application.Quit();
    }
    // for application exit
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

[System.Serializable]
public class InfoText
{
    public string[] options;

    public static InfoText CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<InfoText>(jsonString);
    }
}