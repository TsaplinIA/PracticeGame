using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    const float MIN_SCALE_X = 0.55f;
    const float MAX_SCALE_X = 0.8f;
    const float MIN_SCALE_Y = 0.55f;
    const float MAX_SCALE_Y = 0.9f;
    public float speed;
    public GameObject parent;
    
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(MIN_SCALE_X, MAX_SCALE_X), Random.Range(MIN_SCALE_Y, MAX_SCALE_Y), 1);
        GetComponent<SpriteRenderer>().color = Camera.main.GetComponent<UIScript>().selectColor;
    }


    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= 6.5 || Mathf.Abs(transform.position.y) >= 6.5)
            Destroy(parent);
        transform.Translate(0, speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Enemy>().Damage(GetComponent<SpriteRenderer>().color);
        //Debug.Log("1");
        Destroy(parent);
    }
}
