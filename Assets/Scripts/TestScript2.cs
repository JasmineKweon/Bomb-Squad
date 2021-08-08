using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript2 : MonoBehaviour
{
    public List<SpriteNumber> numbers;

    public GameObject genericNumber;

    public GameObject ParentPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newObj = genericNumber;
            newObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
            newObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 50.0f, 50.0f);
            newObj.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 50.0f, 50.0f);
            newObj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
