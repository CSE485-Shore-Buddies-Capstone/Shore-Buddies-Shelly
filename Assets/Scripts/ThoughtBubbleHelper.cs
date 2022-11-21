using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThoughtBubbleHelper : MonoBehaviour
{
    public TMP_Text infoText;
    public TextAsset jsonFile;
    private InfoText infoTextObj;
    private int currentIndex;

    private void Start() {
        infoTextObj = InfoText.CreateFromJSON(jsonFile.text);
        currentIndex = Random.Range(0, infoTextObj.options.Length);
        SetNewText(false);
    }

    public void SetNewText(bool excludeCurrent = true) {
        if(!excludeCurrent)
            infoText.SetText(infoTextObj.options[Random.Range(0, infoTextObj.options.Length)]);
        else {
            int newIndex = (currentIndex + Random.Range(1, infoTextObj.options.Length)) % infoTextObj.options.Length;
            infoText.SetText(infoTextObj.options[newIndex]);
        }
    }
}
