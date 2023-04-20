using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Witch: MonoBehaviour
{
    public enum Witch_Type {Pot,Juicer,Loster }

    public Witch_Type type;
    private Animator anim;

    public bool isMake_Potion;
    public bool isMake_Sucess;

    private int pot_Fire_Power = 100000;
    private int pot_Spoon_Rotate = 1000000;
    bool potion_Make_Sucess = false;
    public int Pot_Fire_Power
    {
        get { return pot_Fire_Power; }
        set
        {
            pot_Fire_Power = value;
            pot_Fire_Power = Mathf.Clamp(pot_Fire_Power, 100000, 500000);
        }
    }
    public int Pot_Spoon_Rotate
    {
        get { return pot_Spoon_Rotate; }
        set
        {
            pot_Spoon_Rotate = value;
            pot_Spoon_Rotate = Mathf.Clamp(pot_Spoon_Rotate, 1000000, 3000000);
        }
    }

    public int[] pot_ingredient;
    [SerializeField] private ingredient[] ingredient_Idx;
    public int[] trade_Water_List;
    // Start is called before the first frame update
  
    public int potion_Num;

    private void Awake()
    {
        TryGetComponent(out anim);
    }

    // Update is called once per frame
    void Update()
    {
        Input_Pot();
    }

    public void Witch_UI()
    {
        if(type == Witch_Type.Pot)
        {
            Game_UI_Manager.Instance.player_UI_Juicer = false;
            Game_UI_Manager.Instance.player_UI_Loster = false;
            Game_UI_Manager.Instance.player_UI_Pot = true;
        }
        if (type == Witch_Type.Juicer)
        {
            Game_UI_Manager.Instance.player_UI_Juicer = true;
            Game_UI_Manager.Instance.player_UI_Loster = false;
            Game_UI_Manager.Instance.player_UI_Pot = false;
        }
        if (type == Witch_Type.Loster)
        {
            Game_UI_Manager.Instance.player_UI_Juicer = false;
            Game_UI_Manager.Instance.player_UI_Loster = true;
            Game_UI_Manager.Instance.player_UI_Pot = false;
        }
    }

    
    void Input_Pot()
    {

        if (type == Witch_Type.Pot)
        {
            if (Game_UI_Manager.Instance.player_UI_Pot)
            {

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Pot_Fire_Power -= 100000;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Pot_Fire_Power += 100000;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pot_Spoon_Rotate -= 1000000;
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Pot_Spoon_Rotate += 1000000;
                }
            }
            potion_Num = pot_ingredient[0] + pot_ingredient[1] + pot_ingredient[2] + Pot_Fire_Power + Pot_Spoon_Rotate;
            Debug.Log("합 : " + potion_Num);
        }
    }
    public void Make_Potion(int[] ingredient)
    {
       // Debug.Log(ingredient[0]);
       // for (int i = 0; i < ingredient.Length; i++)
       // {
       //     if (ingredient[i] < 40)
       //     {
       //         Debug.Log(ingredient[i]);
       //         return;
       //     }
       // }
        for (int i = 0; i < pot_ingredient.Length; i++)
        {
            Debug.Log(ingredient[i]);
            if (i > 2) break;

            pot_ingredient[i] = ingredient[i];
        }

        if(pot_ingredient[2] == 0)
        {
            pot_ingredient[2] = 0;
        }
    }

    public bool Make_Potion_Number(int potion_Num)
    {
        switch (potion_Num)
        {
         case 2401100:
             potion_Make_Sucess = true;
             break;
         //나쁜풀 제거물약
         case 3330200:
             potion_Make_Sucess = true;
             break;
         //영양 공급 물약
         case 1322300:
             potion_Make_Sucess = true;
             break;
         //부들부들 사탕
         case 3203400:
             potion_Make_Sucess = true;
             break;
         //기침 사탕
         case 3401100:
             potion_Make_Sucess = true;
             break;
         //치료사탕
         case 2310100:
             potion_Make_Sucess = true;
             break;
         case 3511000:
             potion_Make_Sucess = true;
             break;
         //태양빛 물약
         case 2424500:
             potion_Make_Sucess = true;
             break;
         //효자손 사탕
         default:
             potion_Make_Sucess = false;
         break;

        }
        if (potion_Make_Sucess)
        {   Inventory_Manager.Instance.item_Index.Add(potion_Num);
            Inventory_Manager.Instance.Update_Item_Idx();
        }

        for (int i = 0; i < pot_ingredient.Length; i++)
        {
            int k = Inventory_Manager.Instance.item_Index.FindIndex(num => num == pot_ingredient[i]);
            int j = Inventory_Manager.Instance.inventory_Type_List.FindIndex(num => num == pot_ingredient[i]);

            if (k == -1) continue;

            Inventory_Manager.Instance.UI_Position(Inventory_Manager.Instance.UI_Item_Icon_Prefabs
                                                  [item_To_Potion(pot_ingredient[i], 0)],
                                                   Inventory_Manager.Instance.UI_Item_Local_Pos);

            Inventory_Manager.Instance.inventory_Count_List.RemoveAt(j);
            Inventory_Manager.Instance.item_Index.RemoveAt(k);
            Inventory_Manager.Instance.inventory_Temp_List.Clear();
            pot_ingredient[i] = 0;
        }
        return potion_Make_Sucess;
    }

    public int item_To_Potion(int item_idx, int potion_idx)
    {
        
        if (item_idx > 40)
        {
            switch (item_idx)
            {
                //=============가공 재료
                case 100:
                    potion_idx = 19;
                    break;
                case 200:
                    potion_idx = 20;
                    break;
                case 300:
                    potion_idx = 21;
                    break;
                case 400:
                    potion_idx = 22;
                    break;
                case 500:
                    potion_idx = 23;
                    break;
                case 1000:
                    potion_idx = 24;
                    break;
                case 2000:
                    potion_idx = 25;
                    break;
                case 3000:
                    potion_idx = 26;
                    break;
                case 4000:
                    potion_idx = 27;
                    break;
                case 10000:
                    potion_idx = 28;
                    break;
                case 20000:
                    potion_idx = 29;
                    break;
                //============포션
                case 2401100:
                    potion_idx = 30;
                    break;
                case 3330200:
                    potion_idx = 31;
                    break;
                case 1322300:
                    potion_idx = 32;
                    break;
                case 3203400:
                    potion_idx = 33;
                    break;
                case 3401100:
                    potion_idx = 34;
                    break;
                case 2310100:
                    potion_idx = 35;
                    break;
                case 3511000:
                    potion_idx = 36;
                    break;
                case 2424500:
                    potion_idx = 37;
                    break;
            }

        }
            return potion_idx;
    }
    public void Ingreadient_Trade(int source,ref int count)
    {
        if(type == Witch_Type.Juicer)
        {
            anim.SetTrigger("isJuicer");
            switch (source)
            {
                case 7:
                    Result_Trade_Methord(source ,ref count, 0);
                    break;
                case 11:
                    Result_Trade_Methord(source, ref count ,1);
                    break;
                case 9:
                    Result_Trade_Methord(source, ref count, 2);
                    break;
                case 5:
                    Result_Trade_Methord(source, ref count, 3);
                    break;
                case 0:
                    Result_Trade_Methord(source, ref count, 4);
                    break;
                case 13:
                    Result_Trade_Methord(source, ref count, 5);
                    break;
                case 8:
                    Result_Trade_Methord(source, ref count, 6);
                    break;
                case 6:
                    Result_Trade_Methord(source, ref count, 7);
                    break;
                case 3:
                    Result_Trade_Methord(source, ref count, 8);
                    break;
                case 10:
                    Result_Trade_Methord(source, ref count, 9);
                    break;
                case 2:
                    Result_Trade_Methord(source, ref count, 10);
                    break;
                default: return;
            }
        }
        if (type == Witch_Type.Loster)
        {
            switch (source)
            {
                case 7:
                    Result_Trade_Methord(source, ref count, 0);
                    break;
                case 11:
                    Result_Trade_Methord(source, ref count, 1);
                    break;
                case 9:
                    Result_Trade_Methord(source, ref count, 2);
                    break;
                case 5:
                    Result_Trade_Methord(source, ref count, 3);
                    break;
                case 0:
                    Result_Trade_Methord(source, ref count, 4);
                    break;
                case 13:
                    Result_Trade_Methord(source, ref count, 5);
                    break;
                case 8:
                    Result_Trade_Methord(source, ref count, 6);
                    break;
                case 6:
                    Result_Trade_Methord(source, ref count, 7);
                    break;
                case 3:
                    Result_Trade_Methord(source, ref count, 8);
                    break;
                case 10:
                    Result_Trade_Methord(source, ref count, 9);
                    break;
                case 2:
                    Result_Trade_Methord(source, ref count, 10);
                    break;
                default: return;
            }
        }
    }
    void Result_Trade_Methord(int source, ref int count, int i)
    {
        int a = 0;
        int k = 0;
        while (a <= 1)
        {
            k = Inventory_Manager.Instance.item_Index.FindIndex(num => num == source);
            Debug.Log($"1개 이상 남아있을때 : {k}");
            Inventory_Manager.Instance.item_Index.RemoveAt(k);
            a++;
        }
        if (count >= 2)
        {
            count -= 2;
            Inventory_Manager.Instance.item_Index.Add(ingredient_Idx[i].mixture_index);
        }
        if (count <= 0)
        {
            //Inventory_Manager.Instance.item_Index.Add(ingredient_Idx[i].mixture_index);
            Debug.Log($"1개 이상 남아있지 않을 때 : {source}");
            count++;

            Inventory_Manager.Instance.UI_Position(Inventory_Manager.Instance.UI_Item_Icon_Prefabs
                                   [Inventory_Manager.Instance.inventory_Type_List[Game_UI_Manager.Instance.source_Index]], 
                                   Inventory_Manager.Instance.UI_Item_Local_Pos);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == Witch_Type.Loster)
        {
            if (collision.CompareTag("Player"))
            {
                anim.SetBool("Player_Come", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (type == Witch_Type.Loster)
        {
            if (collision.CompareTag("Player"))
            {
                anim.SetBool("Player_Come", false);
            }
        }
    }
}

