using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    float MIN_SCALE_X = 0.55f;
    float MAX_SCALE_X = 0.8f;
    float MIN_SCALE_Y = 0.55f;
    float MAX_SCALE_Y = 0.9f;
    Image img;
    
    void Start()
    {
        img = GetComponent<Image>();
        transform.localScale = new Vector3(Random.Range(MIN_SCALE_X, MAX_SCALE_X), Random.Range(MIN_SCALE_Y, MAX_SCALE_Y), 1);
        GetComponent<SpriteRenderer>().color = Camera.main.GetComponent<UIScript>().selectColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
