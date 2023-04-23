using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Manager : MonoBehaviour
{
    public static Talk_Manager Instance = null;
    Dictionary<int, string[]> talk_Data;
    Dictionary<int, Sprite> pot_Data;

    public Sprite[] pot_Array;
    public int next_Count;

    public int quest_Potion_Num;
    public int potion_Num;
    [SerializeField] private Potion[] potion_info;
    [SerializeField] private GameObject[] rand_Quest;

    private void Awake()
    {
        quest_Potion_Num = Random.Range(0, 4);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        talk_Data = new Dictionary<int, string[]>();
        pot_Data = new Dictionary<int, Sprite>();
        GenerateData();
    }
    public void Trade_Potion()
    {

        quest_Potion_Num = Random.Range(0, 4);
    }
    private void Update()
    {

        for (int i = 0; i < rand_Quest.Length; i++)
        {
            rand_Quest[i].SetActive(true);
            if(i != quest_Potion_Num)
            {
                rand_Quest[i].SetActive(false);
            }
        }
        switch (quest_Potion_Num)
        {
            case 0:
                potion_Num = potion_info[0].mixture_index;
                break;
            case 1:
                potion_Num = potion_info[1].mixture_index;
                break;
            case 2:
                potion_Num = potion_info[2].mixture_index;
                break;
            case 3:
                potion_Num = potion_info[3].mixture_index;
                break;
        }
    }

    void GenerateData()
    {
       // int i = Game_UI_Manager.Instance.Select_Num;
        talk_Data.Add(0, new string[] {
            "에우레아님은 평소에 어떤 음식을 좋아하세요?: 0",
            "월계수 잎으로 우린 따뜻한 차만 있다면 \n 뭐든 상관없어. : 3",
            "월계수 잎이라... 찾게되면 전해드릴께요! : 3",
            "고마워~ : 1" });

        pot_Data.Add(0, pot_Array[0]);
        pot_Data.Add(1, pot_Array[1]);
        pot_Data.Add(2, pot_Array[2]);
        pot_Data.Add(3, pot_Array[3]);

        pot_Data.Add(4, pot_Array[4]);
        pot_Data.Add(5, pot_Array[5]);
        pot_Data.Add(6, pot_Array[6]);
        pot_Data.Add(7, pot_Array[7]);

        pot_Data.Add(8, pot_Array[8]);
        pot_Data.Add(9, pot_Array[9]);
        pot_Data.Add(10, pot_Array[10]);
        pot_Data.Add(11, pot_Array[11]);

        talk_Data.Add(1, new string[] { 
            "이 숲은 정말 평화로운 것 같아요! : 0",
            "엿이나 먹으라지.. 빌어먹을 자연 : 3",
            "에우레아님은 자연을 정말 싫어하시네요. : 3",
            "지겨워 죽겠어. 시끄럽게 우는 벌레나 \n 길을 잃는 상황도 정말 최악이야. : 3",
            "그래도 월계수잎은 필요하신거죠? : 3",
            "....응 : 3"});




      talk_Data.Add(2, new string[] { "오늘의 납품 목록은 이거야! : 2" });

    }

   


    public Sprite GetPortait(int id, int pot_index)
    {
        return pot_Data[id + pot_index];
    }

    public string GetTalk(int id, int talk_Index)
    {
        if (next_Count == talk_Data[id].Length)
        {
            Game_UI_Manager.Instance.select_trigger = false;
            return null;
        }
        else
        {
            return talk_Data[id][talk_Index];

        }
    }
 
}
