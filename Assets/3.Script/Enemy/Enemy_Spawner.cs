using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public enum Spawner_Type
    {
        Tree, MongSiri_Hole, Apple, BushBug
    }
    public Spawner_Type type;
    //============================================= 공용
    [SerializeField] private GameObject enemy_Prefab;
    [SerializeField] private Vector2 poolPos;
    
    public float charge_Button_Count;
    private GameObject[] enemys;
    private Enemy[] enemy_Components;
    public int spawnEnemy_Count;
    private int nextCount;
    bool isSpawn;
    //============================================= 토끼굴 
    private bool isLookAt_to_Spanwer = false;
    public bool failling = false;
    public CircleCollider2D circle;
    public BoxCollider2D box;

    //============================================= 나무
    public Animator anim;
    private bool player_In_Interaction_Area = false;
    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out anim);
        enemy_Components = new Enemy[spawnEnemy_Count];
        enemys = new GameObject[spawnEnemy_Count];

        for (int i = 0; i < spawnEnemy_Count; i++)
        {
            enemys[i] = Instantiate(enemy_Prefab, poolPos, Quaternion.identity, gameObject.transform);
            enemys[i].SetActive(false);
            enemy_Components[i] = transform.GetChild(i).GetComponent<Enemy>();
        }

        switch (type)
        {
            case Spawner_Type.MongSiri_Hole:
                TryGetComponent(out circle);
                break;
            case Spawner_Type.Tree:
                TryGetComponent(out box);
                break;
        }
        Transform_Pos();
    }
    private void OnEnable()
    {
        if (box != null)
        {
            box.enabled = true;
        }
        failling = false;
        if (type == Spawner_Type.Tree)
        {
            charge_Button_Count = 5;
        }

        isSpawn = false;
    }
    // Update is called once per frame
    void Update()
    {
        Enemy_Interaction_Object();
    }
    void Enemy_Interaction_Object()
    {
        switch (type)
        {
            case Spawner_Type.MongSiri_Hole:

                if (isLookAt_to_Spanwer)
                {
                    for (int i = 0; i < enemy_Components.Length; i++)
                    {
                        if (!enemy_Components[i].isCollect)
                        {
                            enemy_Components[i].isLookAt = true;
                        }
                    }
                }

                else if (!isLookAt_to_Spanwer)
                {
                    for (int i = 0; i < enemy_Components.Length; i++)
                    {
                        if (enemy_Components[i].isCollect && enemys[i].activeSelf == true)
                        {
                            enemy_Components[i].isLookAt = false;
                            enemy_Components[i].StartCoroutine("Enemy_Escape");
                        }
                    }
                }
                break;

            case Spawner_Type.Tree:

                if (failling)
                {
                    for(int i = 0; i<spawnEnemy_Count; i++)
                    {
                        float rand_Falling = Random.Range(5,9);
                        Vector2 faillingPos = new Vector2(enemys[i].transform.position.x, enemys[i].transform.localPosition.y + 0.51f);
                        enemys[i].transform.position = Vector3.MoveTowards(enemys[i].transform.position, faillingPos, rand_Falling * Time.deltaTime);
                        anim.SetBool("isInteraction", false);
                        charge_Button_Count = 0;
                        box.enabled = false;
                    }
                }
                break;

            case Spawner_Type.Apple:
            
                if (failling)
                {
                    for (int i = 0; i < spawnEnemy_Count; i++)
                    {
                        float rand_Falling = 5;
                        Vector2 faillingPos = new Vector2(enemys[i].transform.position.x, transform.localPosition.y - 1f);
                        enemys[i].transform.position = Vector3.MoveTowards(enemys[i].transform.position, faillingPos, rand_Falling * Time.deltaTime);
                        anim.SetBool("isInteraction", false);
                        box.enabled = false;
                    }
                }
                break;

            case Spawner_Type.BushBug:

                if (failling)
                {
                    for (int i = 0; i < spawnEnemy_Count; i++)
                    {
                        
                        float rand_Falling = 500;
                        Vector2 faillingPos = new Vector2(enemys[i].transform.position.x, transform.localPosition.y + 0.08f);
                        enemys[i].transform.position = Vector3.MoveTowards(enemys[i].transform.position, faillingPos, rand_Falling * Time.deltaTime);
                        anim.SetBool("isInteraction", false);

                        box.enabled = false;
                        if (!isSpawn)
                        {
                        StartCoroutine(Rate_Spawn(i));
                        isSpawn = true;
                        }
                    }

                }
                break;
        }

    }
    IEnumerator Rate_Spawn(int i)
    {
        yield return new WaitForSeconds(1f);
        enemys[i].SetActive(true);
    }
    void Transform_Pos()
    {
        switch (type)
        {
            case Spawner_Type.MongSiri_Hole:

                while (true)
                {
                    float rand_X = Random.Range(-2f, 2f);
                    float rand_Y = Random.Range(-2f, 2f);
                    Vector2 randPos = new Vector2(transform.position.x + rand_X, transform.position.y + rand_Y);
                    enemys[nextCount].SetActive(true);
                    enemys[nextCount].transform.position = randPos;

                    nextCount++;

                    if (nextCount >= spawnEnemy_Count)
                    {
                        return;
                    }
                }
            case Spawner_Type.Tree:

                while (true)
                {
                    float rand_X = Random.Range(-1f, 1f);
                    float rand_Y = Random.Range(-0.6f, 1f);
                    Vector2 randPos = new Vector2(transform.position.x + rand_X, transform.position.y + rand_Y);
                    enemys[nextCount].SetActive(true);
                    enemys[nextCount].transform.position = randPos;

                    nextCount++;

                    if (nextCount >= spawnEnemy_Count)
                    {
                        return;
                    }
                }

            case Spawner_Type.Apple:

                while (true)
                {
                    Vector2 randPos = new Vector2(transform.position.x, transform.position.y);

                    enemys[nextCount].SetActive(true);
                    enemys[nextCount].transform.position = randPos;
                    nextCount++;

                    if (nextCount >= spawnEnemy_Count)
                    {
                        return;
                    }
                }

            case Spawner_Type.BushBug:

                while (true)
                {
                    Vector2 randPos = new Vector2(transform.position.x, transform.position.y -1f);

                    enemys[nextCount].SetActive(false);
                    enemys[nextCount].transform.position = randPos;
                    nextCount++;

                    if (nextCount >= spawnEnemy_Count)
                    {
                        return;
                    }
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_In_Interaction_Area = true;
            isLookAt_to_Spanwer = true; //플레이어가 들어오면 단 한번 인식하는 bool
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLookAt_to_Spanwer = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < enemy_Components.Length; i++)
            {
                enemy_Components[i].isLookAt = false;
            }
            player_In_Interaction_Area = false;
        }
    }
}
