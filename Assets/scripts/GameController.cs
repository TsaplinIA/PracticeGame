using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    const float MAX_SPEED = 7;
    const float MIN_SPEED = 4;
    const int PRIZE = 55;// prize for destroy enemy
    const float PROGRESS = 0.1f;// how fast speed go up
    public float speed;// speed right now
    public GameObject stars;
    ParticleSystem starSystem;
    List<GameObject> enemys = new List<GameObject>();// all enemys on scene
    const float START_Y = 6.5f;// for spawn enemy
    const float START_X = 1.85f;// for spawn enemy

    public Sprite[] playerTextures;
    public GameObject player;
    public GameObject gun;
    public GameObject gunMarker;
    Transform playerTransform;
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;
    public float bulletTime;// how long gun reload
    float timeNow = 0;
    MemoryScript memory;

    public GameObject target;

    void Start()
    {
        memory = Camera.main.GetComponent<MemoryScript>();
        starSystem = stars.GetComponent<ParticleSystem>();
        starSystem.startSpeed = MIN_SPEED;//set star speed
        playerTransform = player.transform;
        player.GetComponent<SpriteRenderer>().sprite = playerTextures[memory.GetSelect()];
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        //enemyPrefab.transform.TransformDirection(new Vector2(UnityEngine.Random.Range(-START_X,START_X), START_Y));
        GameObject test = Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-START_X, START_X), START_Y, 0), Quaternion.identity);
        enemys.Add(test);
        //Camera.main.GetComponent<UIScript>().bulletsSystem.trigger.
    }

    GameObject GetTarget()//get nearest enemy
    {
        float playerY = playerTransform.position.y;
        GameObject target = null;
        float distance = float.MaxValue;
        foreach (var enemy in enemys)
        {
            Console.WriteLine("!");
            float delta = float.MaxValue;
            if (enemy != null) delta = enemy.transform.position.y - playerY;
            if (target == null || (delta < distance && distance > 0))
            {
                distance = delta;
                target = enemy;
            }
        }
        return target;
    }

    void LookAt2D(Transform itTF, Transform targetTF)// rotate one to the other in 2D space
    {
        Vector3 diff = targetTF.position - itTF.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    
    void CreateBullet() // spawn bullet
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.localRotation = gun.transform.localRotation;
        bullet.transform.position = gunMarker.transform.position;
    }

    public void DestroyEnemy(GameObject enemy)//destroy enemy object and give prize
    {
        enemys.Remove(enemy);
        Destroy(enemy);
        SpawnEnemy();
        memory.AddCoins(PRIZE);
        speed += PROGRESS * (MAX_SPEED - speed);
        starSystem.startSpeed = speed;
    }

    public void GoToMenu()// void for menu button
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (enemys.Count <= 0) SpawnEnemy();
        target = GetTarget();
        if (target != null) LookAt2D(gun.transform, target.transform);
        timeNow += Time.deltaTime;
        if (timeNow >= bulletTime)
        {
            CreateBullet();
            timeNow = 0;
        }
    }
}
