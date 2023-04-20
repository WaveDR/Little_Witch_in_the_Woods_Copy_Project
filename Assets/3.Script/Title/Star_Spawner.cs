using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Spawner : MonoBehaviour
{
    private GameObject[] spawnPos;
    [SerializeField]
    private Transform[] spawnTrans;
    [SerializeField]
    private GameObject shooting_Star;

    private int count = 3;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        SpawnStar();
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(3,6);
        time += Time.deltaTime;
        if(time > rand)
        {
            StartCoroutine(RandSpawn());
            time = 0;
        }

    }

    private void SpawnStar()
    {
        spawnPos = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            spawnPos[i] = Instantiate(shooting_Star, spawnTrans[i].position, Quaternion.identity);
            spawnPos[i].transform.localScale = new Vector3(4, 4, 4);
            spawnPos[i].SetActive(false);
        }
    }
    private IEnumerator RandSpawn()
    {
        int rand = Random.Range(0, 3);
        spawnPos[rand].SetActive(true);
        yield return new WaitForSeconds(1.2f);
        spawnPos[rand].SetActive(false);
    }
}
