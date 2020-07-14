using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Texture2D gradient;
    public GameObject coinsTextObj;
    Text coinsText;
    public Color selectColor = new Vector4(1, 1, 1, 1);
    MemoryScript memory;
    
    
    void Start()
    {
        coinsText = coinsTextObj.GetComponent<Text>();
        memory = Camera.main.GetComponent<MemoryScript>();
    }
    Color GetGradColor(float percent) // calculate select color
    {
        if (percent <= 1 && percent >= 0)
        {
            return gradient.GetPixel((int)(percent * gradient.width), 0);
        }
        return new Vector4(1, 1, 1, 1);
    }

    public Color GetRandomColor()
    {
        return GetGradColor(Random.Range(0f, 1f));
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            selectColor = GetGradColor(Input.mousePosition.x / Camera.main.pixelWidth);// change select color
        }

        coinsText.text = "" + memory.GetCoins();//update coins
    }
}
