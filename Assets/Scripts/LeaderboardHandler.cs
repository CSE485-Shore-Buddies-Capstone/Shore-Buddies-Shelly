using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

/*
 * This file contains how the leaderboard functions 
 */
public class LeaderboardHandler : MonoBehaviour
{
    public InputField memberID;
    public CanvasGroup leaderboardContent;
    public Text scoreText;
    public int id;
    int maxScores = 100;
    public GameObject content;
    private GameObject[] pages;
    private Text[] entries;

    private int score = 0;

    private void Start()
    {
        pages = new GameObject[10];
        entries = new Text[maxScores];
        
        int i = 0;
        int j = 0;
        foreach(Transform child in content.transform) {
            pages[i] = child.gameObject;
            i++;
            foreach(Transform child2 in child.transform) {
                entries[j] = child2.gameObject.GetComponent<Text>();
                j++;
            }
        }

        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {

            SetLeaderboardContent(0, false, false);

            if (response.success)
            {
                Debug.Log("response successful");
                ShowScores();
            }
            else
            {
                Debug.Log(response.text);
                Debug.Log(response.Error);
            }
        });
    }

    public void DetermineIfSubmit()
    {
        if(memberID.text.Length < 1)
        {
            SetResponseProperties(0);
        }
        else
        {
            if(memberID.text.Length >= 1)
            {
                LootLockerSDKManager.GetScoreList(id, maxScores, (response) =>
                {
                    if (response.success)
                    {
                        LootLockerLeaderboardMember[] names = response.items;
                        for (int i = 0; i < names.Length; i++)
                        {
                            if (names[i].member_id.ToLower().Trim() == memberID.text.ToLower().Trim())
                            {
                                SetResponseProperties(1);
                                return;
                            }
                        }
                        SubmitScore();
                    }
                });
            }
        }
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(memberID.text, score, id, (response) =>
        {

            if (response.success)
            {
                Debug.Log("score sent to leaderboard for " + memberID.text);
            }
            else
            {
                Debug.Log(response.text);
                Debug.Log(response.Error);
            }

        });
        ShowScores();
    }

    void SetResponseProperties(int responseCode)
    {
        SetMemberIDColor(false);
        memberID.text = "";
        memberID.gameObject.transform.Find("Placeholder").GetComponent<Text>().text = GetErrorResponse(responseCode);
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(id, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ".   " + scores[i].member_id + " - " + scores[i].score);
                }

                if(scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }
                SetLeaderboardContent(1, true, true);
            }
        });
    }

    public void GoToNextPage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if(pages[i].GetComponent<CanvasGroup>().alpha > 0)
            {
                if(i < pages.Length - 1)
                {
                    pages[i].GetComponent<CanvasGroup>().alpha = 0;
                    pages[i + 1].GetComponent<CanvasGroup>().alpha = 1;
                    return;
                }
            }
        }
    }

    public void GoToLastPage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].GetComponent<CanvasGroup>().alpha > 0)
            {
                if (i - 1 > -1)
                {
                    pages[i].GetComponent<CanvasGroup>().alpha = 0;
                    pages[i -1].GetComponent<CanvasGroup>().alpha = 1;
                    return;
                }
            }
        }
    }

    public void SetMemberID(string _memberID)
    {
        memberID.text = _memberID;
    }

    public void SetLeaderboardContent(int _alpha, bool _blocksRaycasts, bool _interactable)
    {
        leaderboardContent.alpha = _alpha;
        leaderboardContent.blocksRaycasts = _blocksRaycasts;
        leaderboardContent.interactable = _interactable; 
    }

    public void SetMemberIDColor(bool input)
    {
        if (!input)
            memberID.image.color = Color.red;
        else
            memberID.image.color = Color.white;
    }

    string GetErrorResponse(int reason)
    {
        switch (reason)
        {
            case 1:
                return "Name has been used before, please retry...";
            default:
                return "Please enter a valid name!";
        }
    }

    public void updateScore(int s) {
        score = s;
        scoreText.text = "" + score;
    }
}
