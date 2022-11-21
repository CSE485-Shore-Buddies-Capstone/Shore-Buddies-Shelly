using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThoughtBubbleHelper : MonoBehaviour
{
    public TMP_Text infoText;
    public TextAsset jsonFile;
    private InfoText infoTextObj;

    private void Start() {
        infoTextObj = InfoText.CreateFromJSON(jsonFile.text);
        infoText.SetText(infoTextObj.options[Random.Range(0, infoTextObj.options.Length)]);
    }
}
