using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mainly for moving birds in the sky
public class ImageMovement : MonoBehaviour
{
    [Header("Start and end position list are connected together by indexx")]
    public List<GameObject> startPosList;
    public List<GameObject> endPosList;
    private GameObject myImage;
    
    void Start()
    {
        myImage = this.gameObject;
    }

    public void RandomizeMovement(){
        int newMovementIndex = Random.Range(0, startPosList.Count);
        Move(newMovementIndex);
    }

    void Move(int index){
        Vector3 startPos = startPosList[index].transform.position;
        Vector3 endPos = endPosList[index].transform.position;

        // rotate/flip image according to the direction it is heading
        if(startPos.x < endPos.x){
            myImage.transform.rotation = Quaternion.Euler(0,0f,-90f);
        }else{
            myImage.transform.rotation = Quaternion.Euler(0f,0f,0f);
        }

        myImage.transform.position = startPos;
        StartCoroutine(Move(myImage, endPos, 8f));
    }

    public IEnumerator Move(GameObject img, Vector3 endValue, float duration)
    {
        float elapsedTime = 0;
        Vector3 startValue = img.transform.position;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Vector3 newPos = Vector3.Lerp(startValue, endValue, elapsedTime / duration);
            img.transform.position = newPos;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("b")){
            RandomizeMovement();
        }
    }
}
