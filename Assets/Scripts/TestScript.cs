using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Sprite[] numbers;
    public GameObject ParentPanel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            GameObject NewObj = new GameObject();
            Image NewImage = NewObj.AddComponent<Image>();
            NewObj.GetComponent<Image>().sprite = numbers[i];
            //NewImage.sprite = numbers[i];
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 50.0f + i * 50, 50.0f);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 50.0f, 50.0f);
            NewObj.SetActive(true);
        }
        /*
        foreach (Sprite currentSprite in numbers)
        {
            GameObject NewObj = new GameObject();
            Image NewImage = NewObj.AddComponent<Image>();
            NewImage.sprite = currentSprite;
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 50.0f, 50.0f);
            NewObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 50.0f, 50.0f);


            //NewObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 200);
            //Debug.Log("NewObj.GetComponent<RectTransform>()" + NewObj.GetComponent<RectTransform>());
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
