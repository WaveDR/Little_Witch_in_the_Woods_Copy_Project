using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_UI_Manager : MonoBehaviour
{
    public static Game_UI_Manager Instance = null;

    public Object_Witch witch_Juicer;
    public Object_Witch witch_Pot;
    public Object_Witch witch_Loster;
    public GameObject[] tool_Array;
    public GameObject[] potion_Array;

    [SerializeField] private GameObject[] HUD_Book_Tag;

    [SerializeField] private Player player;

    [SerializeField] private GameObject HUD_Stamina;
    [SerializeField] private GameObject HUD_Time;
    [SerializeField] private GameObject HUD_Tool;
    [SerializeField] private GameObject HUD_Potion;
    [SerializeField] private GameObject HUD_Book;
    [SerializeField] private GameObject HUD_Quest;
    [SerializeField] private GameObject HUD_Inventory;
    [SerializeField] private GameObject HUD_Press;

    [SerializeField] private GameObject HUD_Select_Potion;
    [SerializeField] private GameObject HUD_Throw_Potion;

    [SerializeField] private Text HUD_Gold_Coin;
    [SerializeField] private Text HUD_Silver_Coin;

    [SerializeField] private Text HUD_Text_Days;
    [SerializeField] private Text HUD_Text_Time;
    [SerializeField] private Text HUD_Text_Time_APM;

    [SerializeField] private Image HUD_Press_Bar;
    [SerializeField] private Image HUD_Stamina_Bar;
    [SerializeField] private Image HUD_Juicer_Press_Bar;
    [SerializeField] private Image HUD_Pot_Press_Bar;
    [SerializeField] private Image HUD_Loster_Press_Bar;


    public Animator anim;

    [SerializeField] private Transform Gage_Bar_Pos;

     private float HUD_Text_Time_Sec;
     private float HUD_Text_Time_Min;

    //플레이어 도구 변경
    public int player_UI_Tool_Change;
    public int player_UI_Potion_Change;
    //플레이어 ui 켜기 및 행동 제한
    public bool player_UI_Book_On;
    public bool player_UI_Inventory_On;
    public bool player_UI_Quest_On;

    public bool player_UI_Pot;
    public bool player_UI_Juicer;
    public bool player_UI_Loster;


    //플레이어 포션 선택 및 던지기
    public bool player_UI_Select_Potion;
    public bool player_UI_Throw_Potion;
    //플레이어 ui 나가기
    public bool player_UI_Exit;
    //두번눌러 ui 나가기
    private int[] double_Tab_Value = new int[3];

    [SerializeField] private int UI_Page_Move_X;
    [SerializeField] private int UI_Page_Move_Y;
    [SerializeField] private int[] UI_Book_Max_Page;

    //----------------------------------------------------------------------------------------------------------

     public GameObject HUD_Witch_Pot;
     public GameObject HUD_Witch_Juicer;
     public GameObject HUD_Witch_Loster;

    [SerializeField] private GameObject[] HUD_Witch_Juicer_Tag;
    [SerializeField] private RectTransform[] HUD_Witch_Juicer_Tag_Pos;


    [SerializeField] private RectTransform HUD_Witch_Juicer_Move_Icon;

    [SerializeField] private GameObject[] HUD_Witch_Pot_Fire;
    [SerializeField] private GameObject[] HUD_Witch_Pot_Rotate;


    [SerializeField] private GameObject[] HUD_Witch_Loster_Tag;
    [SerializeField] private RectTransform[] HUD_Witch_Loster_Tag_Pos;

    [SerializeField] private RectTransform HUD_Witch_Loster_Move_Icon;

    //----------------------------------------------------------------------------------------------------------

    [SerializeField] private int select_Num =1;
    public int Select_Num
    {
        get { return select_Num; }

        set
        {
            select_Num = value;
            select_Num = Mathf.Clamp(select_Num, 0, 2);
        }
    }
    [SerializeField] private GameObject select_File;
    [SerializeField] private GameObject talk_File;
    [SerializeField] private Text talk_Text;
    public bool select_trigger;

    public Smoke_Anim smoke_Anim;

    public int source_Index;

    public Image npc_Image;
    public Image player_Image;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        TryGetComponent(out anim);

        HUD_Witch_Juicer.SetActive(true);
        HUD_Witch_Pot.SetActive(true);

        witch_Juicer = GameObject.FindGameObjectWithTag("Witch_Obj_Juicer").GetComponent<Object_Witch>();
        witch_Pot = GameObject.FindGameObjectWithTag("Witch_Obj_Pot").GetComponent<Object_Witch>();
        witch_Loster = GameObject.FindGameObjectWithTag("Witch_Obj_Loster").GetComponent<Object_Witch>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        smoke_Anim = GameObject.FindGameObjectWithTag("Smk_Anim").GetComponent<Smoke_Anim>();
        HUD_Press_Bar = GameObject.FindGameObjectWithTag("UI_Gage").GetComponent<Image>();
        HUD_Stamina_Bar = GameObject.FindGameObjectWithTag("UI_Stamina").GetComponent<Image>();


        HUD_Juicer_Press_Bar = GameObject.FindGameObjectWithTag("UI_Juicer").GetComponent<Image>();
        HUD_Pot_Press_Bar = GameObject.FindGameObjectWithTag("UI_Pot").GetComponent<Image>();
        HUD_Loster_Press_Bar = GameObject.FindGameObjectWithTag("UI_Lost").GetComponent<Image>();


        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        HUD_Book.SetActive(false);
        HUD_Inventory.SetActive(false);
        HUD_Press.SetActive(false);
        HUD_Witch_Juicer.SetActive(false);
        HUD_Witch_Pot.SetActive(false);
        talk_File.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Input_UI();
        player_HUD_Sync();
    }
    void Input_UI()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player_UI_Select_Potion = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && !player_UI_Quest_On)
        {
            Inventory_Select_Reset();
            UI_Page_Move_X = 0;
            UI_Page_Move_Y = 0;
            double_Tab_Value[0]++;
            player_UI_Book_On = false;
            player_UI_Inventory_On = true;
            if (double_Tab_Value[0] > 1)
            {
                double_Tab_Value[0] = 0;
                player_UI_Inventory_On = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !player_UI_Quest_On)
        {
            Inventory_Select_Reset();
            UI_Page_Move_X = 0;
            UI_Page_Move_Y = 0;
            double_Tab_Value[1]++;
            player_UI_Inventory_On = false;
            player_UI_Book_On = true;
            if (double_Tab_Value[1] > 1)
            {
                double_Tab_Value[1] = 0;
                player_UI_Book_On = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab) && !player_UI_Book_On && !player_UI_Inventory_On)
        {
            UI_Page_Move_X = 0;
            UI_Page_Move_Y = 0;
            double_Tab_Value[2]++;
            player_UI_Quest_On = true;

            if (double_Tab_Value[2] > 1)
            {
                double_Tab_Value[2] = 0;
                player_UI_Quest_On = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            UI_Page_Move_X = 0;
            UI_Page_Move_Y = 0;
            player_UI_Select_Potion = false;
            player_UI_Inventory_On = false;
            player_UI_Book_On = false;
            player_UI_Quest_On = false;
        }
        Tool_SetActive(tool_Array, player_UI_Tool_Change);
        Tool_SetActive(potion_Array, player_UI_Potion_Change);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player_UI_Tool_Change--;
            anim.SetTrigger("Tool_Left");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Tool_Right");
            player_UI_Tool_Change++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Potion_Left");
            player_UI_Potion_Change--;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Potion_Right");
            player_UI_Potion_Change++;

        }
     

        if (player_UI_Book_On || player_UI_Quest_On || player_UI_Pot || player_UI_Juicer || player_UI_Loster || select_trigger)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Select_Num++;
                UI_Page_Move_X = 0;
                UI_Page_Move_Y++;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Select_Num--;
                UI_Page_Move_X = 0;
                UI_Page_Move_Y--;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                UI_Page_Move_X--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                UI_Page_Move_X++;
            }
        
        }
        Move_Pos_Limit();
        Quest_SetActive();
        Inventory_SetActive();
        Book_SetActive();
        Witch_Juicer();
        Witch_Pot();
        Witch_Loster();
        Select_Subject();
    }

    void Select_Subject()
    {
        if (select_trigger)
        {
            select_File.SetActive(true);
            talk_File.SetActive(true);

            anim.SetBool("Select", select_trigger);
            anim.SetInteger("Select_Num", Select_Num);

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                talk_File.SetActive(false);
                select_File.SetActive(false) ;
                select_trigger = false;
                Select_Num = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Talk(select_Num, select_trigger);
                select_File.SetActive(false);
            }
          
        }
        else
        {
                talk_File.SetActive(false);
                select_File.SetActive(false);
                select_trigger = false;
                Select_Num = 1;
        }
    }
    void Talk(int id, bool isNpc)
    {
        string talkData =  Talk_Manager.Instance.GetTalk(id,Talk_Manager.Instance.next_Count);

        talk_Text.text = "무슨 일로 왔니?";
        if (talkData == null)
        {
            select_trigger = false;
            Talk_Manager.Instance.next_Count = 0;
            return;
            
        }
        if (isNpc)
        {
            talk_Text.text = talkData.Split(':')[0];
            npc_Image.sprite = Talk_Manager.Instance.GetPortait(id, int.Parse(talkData.Split(':')[1]));
        

        }
        select_trigger = true;
        Talk_Manager.Instance.next_Count++;
    }
    void Move_Pos_Limit()
    {
        if (!player_UI_Juicer && !player_UI_Loster)
        {
            if (UI_Page_Move_Y > 3)
            {
                UI_Page_Move_Y = 3;
            }
        }
        if(player_UI_Juicer)
        {
            if (UI_Page_Move_Y > 6)
            {
                UI_Page_Move_Y = 6;
            }
        }
         if (player_UI_Loster)
        {
            if (UI_Page_Move_Y > 3)
            {
                UI_Page_Move_Y = 3;
            }
        }

        if (player_UI_Pot)
        {
            if (player_UI_Potion_Change > 2)
            {
                player_UI_Potion_Change = 2;
            }
            if (player_UI_Potion_Change < 0)
            {
                player_UI_Potion_Change = 0;
            }

            if (player_UI_Tool_Change > 4)
            {
                player_UI_Tool_Change = 4;
            }
            if (player_UI_Tool_Change < 0)
            {
                player_UI_Tool_Change = 0;
            }
        }
        else
        {
            if (player_UI_Potion_Change >=3)
            {
                player_UI_Potion_Change = 3;
            }
            if (player_UI_Potion_Change <= 0)
            {
                player_UI_Potion_Change = 0;
            }

            if (player_UI_Tool_Change >= 3)
            {
                player_UI_Tool_Change = 3;
            }
            if (player_UI_Tool_Change <= 0)
            {
                player_UI_Tool_Change = 0;
            }
        }

        if (UI_Page_Move_Y < 0)
        {
            UI_Page_Move_Y = 0;
        }
        if (UI_Page_Move_X <= 0)
        {
            UI_Page_Move_X = 0;
        }

    }

    void Inventory_Select_Reset()
    {
        Inventory_Manager.Instance.UI_Item_Select_file.SetActive(false);
        Inventory_Manager.Instance.ui_Select = false;
        Inventory_Manager.Instance.ui_Select_idx = 0;
    }
    void Inventory_SetActive()
    {
        if (player_UI_Inventory_On)
        {
            HUD_Inventory.SetActive(true);
        }
        else
        {
            HUD_Inventory.SetActive(false);
        }
    }
    void Quest_SetActive()
    {
        if (player_UI_Quest_On)
        {
            anim.SetBool("Quest_Tab", true);
        }
        else
        {
            anim.SetBool("Quest_Tab", false);
        }
        
    }
    void Book_SetActive()
    {
        if (player_UI_Book_On)
        {
            HUD_Book.SetActive(true);

            for(int i = 0; i< HUD_Book_Tag.Length; i++)
            {
                HUD_Book_Tag[i].SetActive(true);

                if(i != UI_Page_Move_Y)
                {
                    HUD_Book_Tag[i].SetActive(false);
                }

                if (HUD_Book_Tag[i].activeSelf && UI_Page_Move_X > HUD_Book_Tag[i].transform.childCount -1)
                {
                    UI_Page_Move_X = HUD_Book_Tag[i].transform.childCount -1;
                }

                for (int k = 0; k < HUD_Book_Tag[i].transform.childCount; k++)
                {
                    GameObject HUD_Book_Page = HUD_Book_Tag[i].transform.GetChild(k).gameObject;

                    HUD_Book_Page.SetActive(true);
                    if(k != UI_Page_Move_X)
                    {
                        HUD_Book_Page.SetActive(false);
                    }
                }
            }
        }
        else
        {
            HUD_Book.SetActive(false);
        }
    }
    void Tool_SetActive(GameObject[] Array, int array_Obj)
    {
        for(int i = 0; i < Array.Length; i++)
        {
            Array[i].SetActive(true);

            if(i != array_Obj)
            {
                Array[i].SetActive(false);
            }
        }

     // // =====포션
     // for (int i = 0; i < potion_Array.Length; i++)
     // {
     //     potion_Array[i].SetActive(true);
     //
     //     if (i != player_UI_Potion_Change)
     //     {
     //         potion_Array[i].SetActive(false);
     //     }
     // }
     // // =====포션
     //
     // for (int i = 0; i < tool_Array.Length; i++)
     // {
     //     tool_Array[i].SetActive(true);
     //
     //     if (i != player_UI_Tool_Change)
     //     {
     //         tool_Array[i].SetActive(false);
     //     }
     // }
    }

    public void Witch_Pot()
    {
        if (player_UI_Pot)
        {
            player_UI_Inventory_On = true;
            HUD_Witch_Pot.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                player_UI_Inventory_On = false;
                player_UI_Pot = false;
                HUD_Witch_Pot.SetActive(false);
                Inventory_Manager.Instance.pot_idx = 0;
            }

            //불 세기, 젓는 방향
            for(int i = 0; i < HUD_Witch_Pot_Fire.Length; i++)
            {
                HUD_Witch_Pot_Fire[i].SetActive(true);
                if(i != player_UI_Tool_Change)
                {
                    HUD_Witch_Pot_Fire[i].SetActive(false);
                }
            }
            
            for (int i = 0; i < HUD_Witch_Pot_Rotate.Length; i++)
            {
                HUD_Witch_Pot_Rotate[i].SetActive(true);
                if (i != player_UI_Potion_Change)
                {
                    HUD_Witch_Pot_Rotate[i].SetActive(false);
                }
            }

            int potion_Index = witch_Pot.potion_Num;
            Debug.Log(potion_Index);
            Player_Press_Make(1, ref potion_Index);
        } 
    }
    public void Witch_Juicer()
    {
      
        if (player_UI_Juicer)
        {
            HUD_Witch_Juicer.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {

                player_UI_Juicer = false;
                HUD_Witch_Juicer.SetActive(false);

            }

            for (int i =0; i < HUD_Witch_Juicer_Tag_Pos.Length; i++)
            {
                HUD_Witch_Juicer_Tag[i].SetActive(true);

                if (i == UI_Page_Move_Y)
                {
                    HUD_Witch_Juicer_Move_Icon.anchoredPosition = HUD_Witch_Juicer_Tag_Pos[i].anchoredPosition;
                }
                if (i != UI_Page_Move_Y)
                {
                    HUD_Witch_Juicer_Tag[i].SetActive(false);
                }
            }

            int num = 0;
            switch (UI_Page_Move_Y)
            {
                case 0:
                    num = 13;
                    break;
                case 1:
                    num = 11;
                    break;
                case 2:
                    num = 7;
                    break;
                case 3:
                    num = 0;
                    break;
                case 4:
                    num = 6;
                    break;
                case 5:
                    num = 10;
                    break;
                case 6:
                    num = 2;
                    break;
            }

            source_Index = Inventory_Manager.Instance.inventory_Type_List.FindIndex(index => index == num);

            if (source_Index == -1) return;

            int source_Count = Inventory_Manager.Instance.inventory_Count_List[source_Index];
            Player_Press_Make(num, ref source_Count);
        }
        else
        {
            HUD_Witch_Juicer.SetActive(false);
        }
    }
    public void Witch_Loster()
    {
       if (player_UI_Loster)
        {
            HUD_Witch_Loster.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {

                player_UI_Loster = false;
                HUD_Witch_Loster.SetActive(false);

            }

            for (int i = 0; i < HUD_Witch_Loster_Tag_Pos.Length; i++)
            {
                HUD_Witch_Loster_Tag[i].SetActive(true);

                if (i == UI_Page_Move_Y)
                {
                    HUD_Witch_Loster_Move_Icon.anchoredPosition = HUD_Witch_Loster_Tag_Pos[i].anchoredPosition;
                }
                if (i != UI_Page_Move_Y)
                {
                    HUD_Witch_Loster_Tag[i].SetActive(false);
                }
            }

            int num = 0;
            switch (UI_Page_Move_Y)
            {
                //만드라고라
                case 0:
                    num = 9;
                    break;
                //호박 강아지
                case 1:
                    num = 5;
                    break;
                //딸랑 거미
                case 2:
                    num = 8;
                    break;
                //외눈 개구리
                case 3:
                    num = 3;
                    break;
            }

            source_Index = Inventory_Manager.Instance.inventory_Type_List.FindIndex(index => index == num);
 
            if (source_Index == -1) return;

            int source_Count = Inventory_Manager.Instance.inventory_Count_List[source_Index];
            Player_Press_Make(num, ref source_Count);
        }
        else
        {
            HUD_Witch_Loster.SetActive(false);
        }
    }
    public float time = 0;
    public void Player_Press_Make(int source, ref int count)
    {
        if (count >= 2)
        {
            if (time <= 0) time = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                time += Time.deltaTime;
            }
            else
            {
                time -= Time.deltaTime;
            }
            if (time >= 3)
            {
                if (player_UI_Juicer)
                {
                    player.anim.SetTrigger("Juicer");
                    witch_Juicer.Ingreadient_Trade(source, ref count);

                    Inventory_Manager.Instance.Update_Item_Idx();
                    Inventory_Manager.Instance.inventory_Count_List[source_Index] = count;
                    Inventory_Manager.Instance.Update_Text();

                    HUD_Witch_Juicer.SetActive(false);
                    player_UI_Juicer = false;
                    time = 0;
                    return;

                }
                else if (player_UI_Loster)
                {
                    witch_Loster.Ingreadient_Trade(source, ref count);

                    Inventory_Manager.Instance.Update_Item_Idx();
                    Inventory_Manager.Instance.inventory_Count_List[source_Index] = count;
                    Inventory_Manager.Instance.Update_Text();

                    HUD_Witch_Loster.SetActive(false);
                    player_UI_Loster = false;
                    time = 0;
                    return;

                }
                else if (player_UI_Pot)
                {
                    time = 0;
                    smoke_Anim.Bale_Smoke();

                    if (witch_Pot.Make_Potion_Number(count))
                    {
                        smoke_Anim.Sucess_Smoke();
                        Debug.LogError("성공");
                        smoke_Anim.Invoke("Bale_Smoke_off", 2);
                        Inventory_Manager.Instance.pot_idx = 0;

                    }
                    if (!witch_Pot.Make_Potion_Number(count))
                    {
                        smoke_Anim.Sucess_Smoke_Out();
                        player.anim.SetTrigger("Failed");
                        Debug.LogError("실패");
                        smoke_Anim.Invoke("Bale_Smoke_off", 2);
                        Inventory_Manager.Instance.pot_idx = 0;
                    }
                }
            }

            if (player_UI_Juicer)
            {
                HUD_Juicer_Press_Bar.fillAmount = time / 3;
            }
             if (player_UI_Pot)
            {
                HUD_Pot_Press_Bar.fillAmount = time / 3;
            }
             if (player_UI_Loster)
            {
                HUD_Loster_Press_Bar.fillAmount = time / 3;
            }

        }
        else if (count < 2)
        {
            time = 0;
        }
    }
    
    void player_HUD_Sync()
    {
        if (player.charge_Button_Time > 0)
        {
            HUD_Press.SetActive(true);
            HUD_Press.transform.position = Camera.main.WorldToScreenPoint(Gage_Bar_Pos.transform.position);
            HUD_Press_Bar.fillAmount = player.charge_Button_Time / player.charge_Button_Count;
        }
        else
        {
            HUD_Press.SetActive(false);
        }
        HUD_Stamina_Bar.fillAmount = player.player_Cur_Stamina / player.player_Max_Stamina;

        HUD_Text_Time_Sec += Time.deltaTime * 0.5f;

        if(HUD_Text_Time_Sec > 6)
        {
            HUD_Text_Time_Sec = 0;
            HUD_Text_Time_Min++;
        }

        //시간
        string min = string.Format("{0:D2}", (int)HUD_Text_Time_Min);
        string sec = string.Format("{0:D2}", (int)HUD_Text_Time_Sec *10);
        int days = 0;
        int Day_week = days % 7;


        string Day_week_Str = "";

        switch (Day_week)
        {
            case 0:
                Day_week_Str = "MON";
                break;
            case 1:
                Day_week_Str = "TUE";
                break;
            case 2:
                Day_week_Str = "WED";
                break;
            case 3:
                Day_week_Str = "THU";
                break;
            case 4:
                Day_week_Str = "FRI";
                break;
            case 5:
                Day_week_Str = "SAT";
                break;
            case 6:
                Day_week_Str = "SUN";
                break;
        }

        HUD_Text_Time.text = $"{min} : {sec}";

        if(HUD_Text_Time_Min > 12)
        {
            HUD_Text_Time_APM.text = "PM";
        }
        else if (HUD_Text_Time_Min < 12)
        {
            HUD_Text_Time_APM.text = "AM";
        }
        //시간
        if (HUD_Text_Time_Min >= 24)
        {
            days++;
            HUD_Text_Time_Min = 0;
            HUD_Text_Time_Sec = 0;
        }
        string days_Str = string.Format("{0:D2}", days);
        HUD_Text_Days.text = $"{days_Str} {Day_week_Str}";
    }

}