using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NumberRenderer : MonoBehaviour
{
    public List<GameObject> score;
    public Sprite[] numbers;

    public GameObject parentObj;

    //public GameObject genericNumber;

    public void RenderNumber(int aNum)
    {
        //Get Lengths
        int length = aNum.ToString().Length;
        char[] strNum = aNum.ToString().ToCharArray();

        //If There is no numbers in the array, add one
        if (score.Count == 0)
        {
            GameObject NewObj = new GameObject();
            NewObj.AddComponent<Image>();
            NewObj.GetComponent<Image>().sprite = numbers[0];
            NewObj.GetComponent<RectTransform>().SetParent(parentObj.transform);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1.0f, 24.0f);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 13.0f, 24.0f);
            NewObj.SetActive(true);
            score.Add(NewObj);
        }
        //Check to see if there is enough numbers to render the incoming number

        for (int i = 0; i < length; i++)
        {
            if (length > score.Count)
            {
                GameObject NewObj = new GameObject();
                NewObj.AddComponent<Image>();
                NewObj.GetComponent<Image>().sprite = numbers[0];
                NewObj.GetComponent<RectTransform>().SetParent(parentObj.transform);
                NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1.0f + (i + 1) * 24.0f, 24.0f);
                NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 13.0f, 24.0f);
                NewObj.SetActive(true);
                score.Add(NewObj);
            }
        }


        //Finally Set the number to each number in the array

        for (int i = 0; i < score.Count; i++)
        {
            score[i].GetComponent<Image>().sprite = numbers[(int.Parse(strNum[i].ToString()))];
        }
    }
}
