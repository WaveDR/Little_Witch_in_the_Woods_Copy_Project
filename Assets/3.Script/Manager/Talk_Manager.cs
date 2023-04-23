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
    private void Awake()
    {
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

    void GenerateData()
    {
       // int i = Game_UI_Manager.Instance.Select_Num;
        talk_Data.Add(0, new string[] {
            "���췹�ƴ��� ��ҿ� � ������ �����ϼ���?: 0",
            "����� ������ �츰 ������ ���� �ִٸ� \n ���� �������. : 3",
            "����� ���̶�... ã�ԵǸ� ���ص帱����! : 3",
            "����~ : 1" });

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
            "�� ���� ���� ��ȭ�ο� �� ���ƿ�! : 0",
            "���̳� ��������.. ������� �ڿ� : 2",
            "���췹�ƴ��� �ڿ��� ���� �Ⱦ��Ͻó׿�. : 2",
            "���ܿ� �װھ�. �ò����� ��� ������ \n ���� �Ҵ� ��Ȳ�� ���� �־��̾�. : 2",
            "�׷��� ��������� �ʿ��ϽŰ���? : 2",
            "....�� : 3"});




      talk_Data.Add(2, new string[] { "������ ��ǰ ����� �̰ž�! : 0" });



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
