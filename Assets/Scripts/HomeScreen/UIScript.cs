using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject desktopLeaderboard, mobileLeaderboard;

    public void setLeaderBoardActive(bool active) {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            mobileLeaderboard.SetActive(active);
        else
            desktopLeaderboard.SetActive(active);
    }
}
