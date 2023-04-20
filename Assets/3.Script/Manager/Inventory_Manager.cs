using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Inventory_Manager : MonoBehaviour
{
    public List<int> item_Index;

    public static Inventory_Manager Instance = null;

    // [SerializeField] private List<int> item_Type_Array;
    // [SerializeField] private List<int> item_Count_Array;

    public List<int> inventory_Temp_List = new List<int>();
    public List<int> inventory_Type_List = new List<int>();
    public List<int> inventory_Count_List = new List<int>();

    public GameObject[] UI_Item_Icon_Prefabs;
    [SerializeField] private GameObject[] UI_PickUp_Icon_Prefabs;

    [SerializeField] private RectTransform[] UI_Item_Icon_Pos;
    [SerializeField] private RectTransform[] UI_Potion_Icon_Pos;
    [SerializeField] private RectTransform[] UI_Item_Select_Pos;

    [SerializeField] private Text[] UI_Item_Icon_Text;

    [SerializeField] private int inventory_Move;
    [SerializeField] private int inventory_Select_Move;

    [SerializeField] private RectTransform UI_Item_Icon_Move;
    [SerializeField] private RectTransform UI_Item_Select_Move;

    public GameObject UI_Item_Select_file;

    [SerializeField] private GameObject PickUp_Item;
    [SerializeField] private Transform PickUp_Pos;
    [SerializeField] private RectTransform PickUp_Item_Pos;

    [SerializeField] private RectTransform[] UI_Witch_Pot_Tag_Pos;

    public RectTransform UI_Item_Local_Pos;

    public bool ui_Select = false;
    public bool ui_Select_Pick_Up = false;
    public int ui_Select_idx = 0;
    int item_idx = 0;
    int potion_idx = 0;
    public int pot_idx = 0;

    private Object_Witch Witch_Tool;
    private int inventory_Move_Limit
    {
        get { return inventory_Move; }
        set
        {
            inventory_Move = value;
            inventory_Move = Mathf.Clamp(inventory_Move, 0, 7);
        }
    }
    private int inventory_Select_Limit
    {
        get { return inventory_Select_Move; }
        set
        {
            inventory_Select_Move = value;
            inventory_Select_Move = Mathf.Clamp(inventory_Select_Move, 0, 2);
        }
    }

    private void Awake()
    {
        Witch_Tool = GameObject.FindGameObjectWithTag("Witch_Obj_Pot").GetComponent<Object_Witch>();
        UI_Item_Select_file.SetActive(false);
        inventory_Select_Limit = 0;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        Inventory_Move_Method();
    }

    public void Inventory_Move_Method()
    {
        //인벤토리 on
        if (Game_UI_Manager.Instance.player_UI_Inventory_On)
        {
            if (!Game_UI_Manager.Instance.player_UI_Pot)
            {
                //인벤토리에서 아이템을 선택했을때
                if (Input.GetKeyDown(KeyCode.Z) && ui_Select_idx == 0)
                {
                    UI_Item_Select_file.SetActive(true);
                    ui_Select = true;
                }
            }
            else
            {
                //인벤토리에서 마녀솥에 넣을 아이템을 선택했을때
                if (Input.GetKeyDown(KeyCode.Z))
                {

                    if (pot_idx >= 3) pot_idx = 3;
                    
                    if (Witch_Tool.pot_ingredient.Length <= 3)
                    {
                        if(pot_idx <= 2)
                        {
                            if(inventory_Type_List[inventory_Move_Limit] > 40)
                            {
                                Debug.Log(inventory_Type_List[inventory_Move_Limit]);
                                Witch_Tool.pot_ingredient[pot_idx] = inventory_Type_List[inventory_Move_Limit];
                                inventory_Temp_List.Add(inventory_Type_List[inventory_Move_Limit]);
                                //아이템 이동 표식
                                for (int i = 0; i < UI_Witch_Pot_Tag_Pos.Length; i++)
                                {
                                    item_idx = inventory_Type_List[inventory_Move_Limit];
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

                                    UI_Position(UI_Item_Icon_Prefabs[potion_idx], UI_Witch_Pot_Tag_Pos[pot_idx]);

                                    Witch_Tool.Make_Potion(Witch_Tool.pot_ingredient);
                                }
                                pot_idx++;
                            }
                        }
                     
                        // inventory_Type_List.RemoveAt(inventory_Select_Limit);
                    }
                    else
                    {
                        Debug.Log("가마솥 용량 초과!!");
                    }
                }

            }
            //아이템 사용선택 안할 시
            if (!ui_Select)
                {
                    //인벤토리 내 사용자 이동 키 최대치 제한
                    if (inventory_Move_Limit <= 3 && Input.GetKeyDown(KeyCode.UpArrow)) return;
                    if (inventory_Move_Limit >= 4 && Input.GetKeyDown(KeyCode.DownArrow)) return;


                    if (Input.GetKeyDown(KeyCode.DownArrow)) inventory_Move_Limit += 4;

                    if (Input.GetKeyDown(KeyCode.UpArrow)) inventory_Move_Limit -= 4;

                    if (Input.GetKeyDown(KeyCode.RightArrow)) inventory_Move_Limit++;

                    if (Input.GetKeyDown(KeyCode.LeftArrow)) inventory_Move_Limit--;


                }
                //아이템 사용 선택 할 시
                else
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow)) inventory_Select_Limit++;
                    if (Input.GetKeyDown(KeyCode.UpArrow)) inventory_Select_Limit--;

                    //아이템 사용 설정 선택
                    if (Input.GetKeyDown(KeyCode.Space) && inventory_Select_Limit == 0)
                    {
                        switch (inventory_Select_Limit)
                        {
                            case 0:
                                ui_Select_Pick_Up = true;
                                ui_Select_idx = 0;
                                UI_Item_Select_file.SetActive(false);
                                Game_UI_Manager.Instance.player_UI_Inventory_On = false;
                                break;

                            case 1:
                                break;

                            case 2:
                                ui_Select = false;
                                ui_Select_Pick_Up = false;
                                UI_Item_Select_file.SetActive(false);
                                break;
                        }
                    }
                }
        }

        //들기 시

        if (ui_Select_Pick_Up)
        {
            PickUp_Item.SetActive(true);
            UI_PickUp_Position(inventory_Type_List[inventory_Move_Limit]);


            //취소
            if (Input.GetKeyDown(KeyCode.X))
            {
                UI_Item_Select_file.SetActive(false);
                ui_Select_Pick_Up = false;
            }
            //버리기
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                UI_Position(UI_Item_Icon_Prefabs[inventory_Type_List[inventory_Move_Limit]], UI_Item_Local_Pos);
                item_Index.RemoveAll(num => num == inventory_Type_List[inventory_Move_Limit]);
                inventory_Count_List.RemoveAt(inventory_Move_Limit);
                inventory_Type_List.RemoveAt(inventory_Move_Limit);

                Update_Item_Idx();

                for (int i = 0; i < inventory_Type_List.Count; i++)
                {
                    item_idx = inventory_Type_List[i];

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

                        UI_Position(UI_Item_Icon_Prefabs[potion_idx], UI_Item_Icon_Pos[i]);
                    }
                    else if (item_idx < 40)
                    {

                        UI_Position(UI_Item_Icon_Prefabs[item_idx], UI_Item_Icon_Pos[i]);
                    }
                }
                PickUp_Item.SetActive(false);
                ui_Select_Pick_Up = false;
            }
        }
        else
        {
            PickUp_Item.SetActive(false);
        }

        //커서 이동
        UI_Item_Icon_Move.anchoredPosition = UI_Item_Icon_Pos[inventory_Move_Limit].anchoredPosition;

        UI_Item_Select_Move.anchoredPosition = UI_Item_Select_Pos[inventory_Select_Limit].anchoredPosition;

        //아이템 들기 시 플레이어 HUD
        PickUp_Item.transform.position = Camera.main.WorldToScreenPoint(PickUp_Pos.transform.position);
    }
    public void Update_Item_Idx()
    {
        //linq와 람다식을 활용
        //얻은 아이템의 개수와 종류를 구분

        //복사 리스트의 중복 삭제
        item_idx = 0;

        inventory_Type_List = item_Index.Distinct().ToList();

        for (int i = 0; i < inventory_Type_List.Count; i++)
        {
            item_idx = inventory_Type_List[i];
            if (!ui_Select_Pick_Up)
            {
                if (item_Index[item_Index.Count - 1] == inventory_Type_List[i])
                {
                    Debug.Log($"중복인 숫자 : {inventory_Type_List[i]}");
                    inventory_Count_List[i]++;
                }

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
                    UI_Position(UI_Item_Icon_Prefabs[potion_idx], UI_Item_Icon_Pos[i]);
                    UI_Item_Icon_Text[potion_idx].text = $"{inventory_Count_List[i]}";
                }
                else if (item_idx < 40)
                {
                    UI_Position(UI_Item_Icon_Prefabs[item_idx], UI_Item_Icon_Pos[i]);
                    UI_Item_Icon_Text[item_idx].text = $"{inventory_Count_List[i]}";
                }
            }
        }

    }

    public void Update_Text()
    {
        // bool isContinue = false;
        // int k = inventory_Count_List.FindIndex(num => num == 0);

        for (int i = 0; i < inventory_Count_List.Count; i++)
        {
            if (i > 0 && inventory_Count_List[i - 1] == 0 && inventory_Count_List != null)
            {
                inventory_Count_List[i - 1] = inventory_Count_List[i];
                inventory_Count_List[i] = 0;
            }

            if (i < inventory_Type_List.Count)
            {
                item_idx = inventory_Type_List[i];
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
                    default: return;
                }

                if (item_idx > 40)
                {
                    UI_Item_Icon_Text[potion_idx].text = $"{inventory_Count_List[i]}";
                }
                else if (item_idx < 40)
                {
                    UI_Item_Icon_Text[item_idx].text = $"{inventory_Count_List[i]}";
                }
            }

            // if(inventory_Type_List.Count < i+1)
            // {
            //     Debug.Log("현재 타입 리스트 갯수"+inventory_Type_List.Count);
            //     Debug.Log("0이 시작되는 인덱스" + i);
            //     inventory_Count_List[i] = 0;
            // }
        }
    }
    public void UI_Position(GameObject prefabs, RectTransform pos)
    {
        prefabs.SetActive(true);
        RectTransform rect = prefabs.GetComponent<RectTransform>();

        rect.anchoredPosition = pos.anchoredPosition;

    }

    void UI_PickUp_Position(int Pick_Num)
    {
        for (int i = 0; i < UI_PickUp_Icon_Prefabs.Length; i++)
        {
            UI_PickUp_Icon_Prefabs[i].SetActive(true);

            if (i != Pick_Num)
            {
                UI_PickUp_Icon_Prefabs[i].SetActive(false);
            }
        }
    }
}