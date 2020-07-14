using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    const float MIN_SCALE = 1;
    const float MAX_SCALE = 2;
    const float MIN_HP = 1000;
    const float MAX_HP = 2000;
    const float ORDER = -2.5f;
    const float MAX_DELTA = 3;
    const float DAMAGE = 700;
    public float speed;// speed enemy
    public float hp;// health
    
    UIScript colorControler;
    public Color myColor;

        
    void Start()
    {
        hp = UnityEngine.Random.Range(MIN_HP, MAX_HP);// set random health
        float sc = MIN_SCALE + (MAX_SCALE - MIN_SCALE) * (hp - MIN_HP) / (MAX_HP - MIN_HP); // coise scale
        transform.localScale = new Vector2(sc, sc);// sel scale
        
        colorControler = Camera.main.GetComponent<UIScript>();
        myColor = colorControler.GetRandomColor();
        GetComponent<SpriteRenderer>().color = myColor;

        speed = Camera.main.GetComponent<GameController>().speed;
    }

    
    void Update()
    {
        if (hp <= 0)
        {
            Camera.main.GetComponent<GameController>().DestroyEnemy(this.gameObject);//enemy dead
        }
        if (transform.position.y < ORDER)
        {
            Camera.main.GetComponent<GameController>().GoToMenu();//player lose
        }
        transform.Translate(new Vector3(0, -speed/100, 0));//enemy move
    }

    public void Damage(Color color)
    {
        float delta =
            Mathf.Abs(color.r - myColor.r)
            + Mathf.Abs(color.g - myColor.g)
            + Mathf.Abs(color.b - myColor.b);//calculate congeniality

        hp -= DAMAGE * (1 - delta/MAX_DELTA);//set damage
    }
}