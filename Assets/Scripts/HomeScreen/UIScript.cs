using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject desktopLeaderboard, mobileLeaderboard;
    public GameObject desktopSettings, mobileSettings;

    public void setLeaderBoardActive(bool active) {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            mobileLeaderboard.SetActive(active);
        else
            desktopLeaderboard.SetActive(active);
    }

    public void setSettingsActive(bool active) {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            mobileSettings.SetActive(active);
        else
            desktopSettings.SetActive(active);
    }
}
