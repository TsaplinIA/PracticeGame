using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject[] imgs;
    public GameObject[] priseObjs;
    public GameObject[] backgroundArr;
    public bool[] isAccessArr = new bool[6];
    public int[] priseArr;
    MemoryScript memory;
    public GameObject coins;
    Text coinsText;
    int select;
    
    void Start()
    {
        memory = Camera.main.GetComponent<MemoryScript>();
        memory.OpenAccess(0);
        coinsText = coins.GetComponent<Text>();
        select = memory.GetSelect();
        for (int i = 0; i <= isAccessArr.Length - 1; i++) 
        {
            priseObjs[i].GetComponent<Text>().text = "" + priseArr[i];
            bool isAccess = memory.GetAccess(i);
            isAccessArr[i] = isAccess;

            if (isAccess)
            {
                imgs[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
                priseObjs[i].SetActive(false);
                backgroundArr[i].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
            }
            else
            {
                imgs[i].GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, 1);
                priseObjs[i].SetActive(true);
                backgroundArr[i].GetComponent<SpriteRenderer>().color = new Vector4(0.5f, 0.5f, 0.5f, 1);
            }

            if (i == select)
                backgroundArr[i].GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 1, 1);

        }
    }


    public void OpenAccess(int number)
    {
        if (priseArr[number] <= memory.GetCoins() && !isAccessArr[number])
        {
            memory.TakeAwayCoins(priseArr[number]);
            memory.OpenAccess(number);
            isAccessArr[number] = true;
            imgs[number].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
            priseObjs[number].SetActive(false);
            SetSelect(number);
        }
    }

    public void CloseAccess(int number)
    {
        memory.TakeAwayCoins(priseArr[number]);
        memory.CloseAccess(number);
        imgs[number].GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, 1);
        priseObjs[number].SetActive(true);
    }

    public void SetSelect(int number)
    {
        if (isAccessArr[number])
        {
            backgroundArr[select].GetComponent<SpriteRenderer>().color = Color.white;
            backgroundArr[number].GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 1, 1);
            select = number;
            memory.SetSelect(number);
        }
    }
    // Update is called once per frame
    void Update()
    {
        coinsText.text = "" + memory.GetCoins();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("ClearMemory");
            memory.AddCoins(2000);
        }
    }

    public void Play()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene(1);
    }
}
