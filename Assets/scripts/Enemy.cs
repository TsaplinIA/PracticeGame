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
    public float speed;
    public float hp;
    SpriteRenderer sr;
    UIScript colorControler;
    public Color myColor;

        
    void Start()
    {
        hp = UnityEngine.Random.Range(MIN_HP, MAX_HP);
        float sc = MIN_SCALE + (MAX_SCALE - MIN_SCALE) * (hp - MIN_HP) / (MAX_HP - MIN_HP);
        transform.localScale = new Vector2(sc, sc);
        sr = GetComponent<SpriteRenderer>();
        colorControler = Camera.main.GetComponent<UIScript>();

        myColor = colorControler.GetRandomColor();
        sr.color = myColor;
        speed = Camera.main.GetComponent<GameController>().speed;
    }

    
    void Update()
    {
        if (hp <= 0)
        {
            Camera.main.GetComponent<GameController>().DestroyEnemy(this.gameObject);
        }
        if (transform.position.y < ORDER)
        {
            Camera.main.GetComponent<GameController>().GoToMenu();
        }
        transform.Translate(new Vector3(0, -speed/100, 0));
    }

    public void Damage(Color color)
    {
        float delta =
            Mathf.Abs(color.r - myColor.r)
            + Mathf.Abs(color.g - myColor.g)
            + Mathf.Abs(color.b - myColor.b);

        hp -= DAMAGE * (1 - delta/MAX_DELTA);
    }

    
}