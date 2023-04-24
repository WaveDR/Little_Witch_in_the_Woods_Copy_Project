using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator anim;

    private float player_Move_Speed;

    private float player_Move_X;
    private float player_Move_Y;
    private bool player_Run;
    private bool player_Action;
    public bool player_Action_Swing;
    private bool player_Action_Charge;

    private bool isAction;
    private bool use_Interaction;

    private Rigidbody2D rigid;
    public Collider2D collision_Target;
    public Collider2D collision_Spawner_Target;
    private BoxCollider2D box;

    public float charge_Button_Time;
    public float charge_Button_Count;
    public float player_Cur_Stamina;
    public float player_Max_Stamina;

    public GameObject wallObj;
    public bool isTree = false;
    Vector2 dirVec;
    // Start is called before the first frame update

    void Awake()
    {
        TryGetComponent(out box);
        use_Interaction = false;
        isAction = false;
        TryGetComponent(out rigid);
        TryGetComponent(out anim);
        player_Move_Speed = speed;
        box.enabled = false;
    }
    private void FixedUpdate()
    {
        Player_Ray_Cast_Hit();
    }
    // Update is called once per frame
    void Update()
    {
        Player_Input(collision_Target,collision_Spawner_Target);
        Player_Anim();
    }

    void Player_Ray_Cast_Hit()
    {

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f,
            LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            isAction = true;
            wallObj = rayHit.collider.gameObject;
        }
        else
        {
            isAction = false;
            wallObj = null;

        }



        if (player_Move_Y > 0)
        {
            dirVec = new Vector2(0, 1);
        }
        if (player_Move_Y <= 0)
        {
            dirVec = new Vector2(0, -1);
        }
        if (player_Move_X > 0)
        {
            dirVec = new Vector2(1, 0);
        }
        if (player_Move_X < 0)
        {
            dirVec = new Vector2(-1, 0);
        }

        //우측 하단
        if (player_Move_X > 0 && player_Move_Y < 0)
        {
            dirVec = new Vector2(1, -1);
        }
        //우측 상단
        if (player_Move_X > 0 && player_Move_Y > 0)
        {
            dirVec = new Vector2(1, 1);
        }
        //좌측 상단
        if (player_Move_X < 0 && player_Move_Y < 0)
        {
            dirVec = new Vector2(-1, -1);
        }
        //좌측 하단
        if (player_Move_X < 0 && player_Move_Y > 0)
        {
            dirVec = new Vector2(-1, 1);
        }


    }
    private void Player_Input(Collider2D collision_Target, Collider2D collision_Spawner_Target)
    {
        if (!Game_UI_Manager.Instance.player_UI_Quest_On && !Game_UI_Manager.Instance.player_UI_Book_On && !Game_UI_Manager.Instance.player_UI_Inventory_On 
          && !Game_UI_Manager.Instance.player_UI_Juicer && !Game_UI_Manager.Instance.player_UI_Loster && !Game_UI_Manager.Instance.player_UI_Pot
          && !Game_UI_Manager.Instance.select_trigger && !Game_UI_Manager.Instance.player_UI_Quest)
        {
            player_Move_X = Input.GetAxisRaw("Horizontal");
            player_Move_Y = Input.GetAxisRaw("Vertical");
            player_Run = Input.GetKey(KeyCode.LeftShift);

            player_Action_Charge = Input.GetKey(KeyCode.Space);
        }



        if (player_Move_Speed == 0)
        {
            SoundManager.Instance.Stop_Sound_Effect("Move_Player");
            SoundManager.Instance.Stop_Sound_Effect("Run_Player");
        }
        if (player_Run )
        {
            player_Move_Speed = 5;
        }
        else if (!player_Run )
        {
            player_Move_Speed = speed;
        }

        if (isAction ||Game_UI_Manager.Instance.player_UI_Quest_On || Game_UI_Manager.Instance.player_UI_Book_On || Game_UI_Manager.Instance.player_UI_Inventory_On
            || Game_UI_Manager.Instance.player_UI_Juicer || Game_UI_Manager.Instance.player_UI_Loster || Game_UI_Manager.Instance.player_UI_Pot || Game_UI_Manager.Instance.select_trigger
            || Game_UI_Manager.Instance.player_UI_Quest
            )
        {
           
            player_Move_Speed = 0;
        }

        if (Game_UI_Manager.Instance.player_UI_Tool_Change == 0)
        {
            anim.SetBool("Mode_Swing", false);
            player_Action = Input.GetKeyDown(KeyCode.Z);
        }
        else if(Game_UI_Manager.Instance.player_UI_Tool_Change == 2)
        {
            player_Action_Swing = Input.GetKeyDown(KeyCode.Z);
        }

        if (collision_Spawner_Target == null && collision_Target == null )
        {
            return;
        }
        if (use_Interaction)
        {
            if (player_Action)
            {
                //무언가를 주울때
                if (collision_Target.CompareTag("Enemy"))
                {
                    Enemy enemy = collision_Target.GetComponent<Enemy>();
                    if (enemy.type == Enemy.Enemy_Type.BushBug)
                    {
                        return;
                    }

                    StopCoroutine(Player_Rooting(enemy));
                    StartCoroutine(Player_Rooting(enemy));
                }

                //마녀 오브젝트 상호작용
                if (collision_Target.CompareTag("Witch_Obj_Juicer") )
                {
                    Object_Witch witch_Tool = collision_Target.GetComponent<Object_Witch>();
                    SoundManager.Instance.Play_Sound_Effect("Witch_Juicer_Open");
                    witch_Tool.Witch_UI();
                }
                if (collision_Target.CompareTag("Witch_Obj_Pot"))
                {
                    Object_Witch witch_Tool = collision_Target.GetComponent<Object_Witch>();
                    SoundManager.Instance.Play_Sound_Effect("Witch_Pot_Open");
                    witch_Tool.Witch_UI();
                }
                if (collision_Target.CompareTag("Witch_Obj_Loster"))
                {
                    Object_Witch witch_Tool = collision_Target.GetComponent<Object_Witch>();

                    witch_Tool.Witch_UI();
                }

                if (collision_Target.CompareTag("NPC"))
                {
                    Game_UI_Manager.Instance.select_trigger = true;

                }
            }
            if (collision_Spawner_Target == null)
            {
                return;
            }
            //나무나 풀 숲 뒤질때

            if (collision_Spawner_Target.CompareTag("Escape_Hole"))
             {
                Enemy_Spawner spawner = collision_Spawner_Target.GetComponent<Enemy_Spawner>();
                if (player_Action_Charge)
                {
                 
                    if(spawner.type == Enemy_Spawner.Spawner_Type.BushBug )
                    {
                        SoundManager.Instance.Play_Sound_Effect("Spawn_BushBug");
                    }
                      
                    else if (spawner.type == Enemy_Spawner.Spawner_Type.Apple)
                    {
                        SoundManager.Instance.Play_Sound_Effect("Spawn_BushBug");
                    }
                    else if (spawner.type == Enemy_Spawner.Spawner_Type.Tree && !isTree)
                    {
                        SoundManager.Instance.Play_Sound_Effect("Collect_Tree");
                        isTree = true;
                    }
                    charge_Button_Count = spawner.charge_Button_Count;
                    charge_Button_Time += Time.deltaTime;

                    if (charge_Button_Time >= charge_Button_Count)
                    {
                        spawner.failling = true;
                        charge_Button_Time = 0;
                    }

                    if (spawner.type == Enemy_Spawner.Spawner_Type.Tree || spawner.type == Enemy_Spawner.Spawner_Type.Apple
                     || spawner.type == Enemy_Spawner.Spawner_Type.BushBug)
                    {
                        spawner.anim.SetBool("isInteraction", true);

                    }
                }
                else if(!(player_Action_Charge))
                {
                    charge_Button_Count = 1;
                    charge_Button_Time = 0; 
                }
            }
            
            if (player_Action_Swing)
            {
                if (collision_Target.CompareTag("Enemy"))
                {
                    Enemy enemy = collision_Target.GetComponent<Enemy>();

                    if (enemy.type != Enemy.Enemy_Type.BushBug)
                    {
                        return;
                    }
                    anim.SetBool("Mode_Swing", true);
                    box.enabled = true;
                    StopCoroutine(Player_Rooting(enemy));
                    StartCoroutine(Player_Rooting(enemy));
                }
            }
        }

    }
    IEnumerator Move_Sound()
    {
        if (player_Run && player_Move_Speed != 0)
        {
            SoundManager.Instance.Play_Sound_Effect("Run_Player");
            yield return new WaitForSeconds(0.3f);
            SoundManager.Instance.Stop_Sound_Effect("Run_Player");

        }
        else if (!player_Run && player_Move_Speed != 0)
        {
            SoundManager.Instance.Play_Sound_Effect("Move_Player");
            yield return new WaitForSeconds(0.3f);
            SoundManager.Instance.Stop_Sound_Effect("Move_Player");

        }

    }
    IEnumerator SwingDeray()
    {
        yield return new WaitForSeconds(0.4f);
        box.enabled = false;
        anim.SetBool("Mode_Swing", false);
    }
    void SwingDir(Vector2 enemy_Vec)
    {
        float player_Vec_X = transform.position.x;
        float player_Vec_Y = transform.position.y;
        float target_Vec_X = enemy_Vec.x;
        float target_Vec_Y = enemy_Vec.y;


        //적이 플레이어보다 우측상단에 존재할경우
        if (player_Vec_X < target_Vec_X && player_Vec_Y < target_Vec_Y)
        {
        
            anim.SetInteger("Swing_Dir", 1);
            //Debug.Log("우측상단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }
        //적이 플레이어보다 좌측상단에 존재할경우
        if (player_Vec_X > target_Vec_X && player_Vec_Y < target_Vec_Y)
        {
            anim.SetInteger("Swing_Dir", 5);
            //Debug.Log("좌측상단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }
        //적이 플레이어보다 우측하단에 존재할경우
        if (player_Vec_X < target_Vec_X && player_Vec_Y > target_Vec_Y)
        {
            anim.SetInteger("Swing_Dir", 2);
           // Debug.Log("우측하단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }
        //적이 플레이어보다 좌측하단에 존재할경우
        if (player_Vec_X > target_Vec_X && player_Vec_Y < target_Vec_Y)
        {
            anim.SetInteger("Swing_Dir", 4);
            //Debug.Log("좌측하단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }
        //적이 플레이어보다 상단에 존재할경우
        if (player_Vec_X == target_Vec_X && player_Vec_Y < target_Vec_Y)
        {
            anim.SetInteger("Swing_Dir", 6);
            //.Log("상단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }
        //적이 플레이어보다 하단에 존재할경우
        if (player_Vec_X < target_Vec_X && player_Vec_Y == target_Vec_Y)
        {
            anim.SetInteger("Swing_Dir", 3);

           // Debug.Log("하단 내 위치 :" + transform.position + "상대 위치 :" + enemy_Vec);
        }

    }
    private void Player_Anim()
    {
        rigid.velocity = new Vector2(player_Move_X * player_Move_Speed, player_Move_Y * player_Move_Speed);
        if (player_Move_X != 0 || player_Move_Y != 0)
        {
          //  StartCoroutine(Move_Sound());
        }
        else if (player_Move_X == 0 || player_Move_Y == 0)
        {
          //  SoundManager.Instance.Stop_Sound_Effect("Move_Player");
          //  SoundManager.Instance.Stop_Sound_Effect("Run_Player");
        }


        if (anim.GetInteger("Move_X") != player_Move_X)
        {
            anim.SetBool("isMove", true);
            anim.SetInteger("Move_X", (int)player_Move_X);
        }

        else if (anim.GetInteger("Move_Y") != player_Move_Y)
        {
            anim.SetBool("isMove", true);
            anim.SetInteger("Move_Y", (int)player_Move_Y);
        }
        else
        {
            anim.SetBool("isMove", false);
        }

        if (player_Move_X == 0 && player_Move_Y == 0)
        {
            anim.SetBool("isDontMove", true);
        }
        else anim.SetBool("isDontMove", false);


        if (player_Run)
        {
            anim.SetBool("isRun", true);
        }
        else anim.SetBool("isRun", false);
    }
    public IEnumerator Player_Rooting(Enemy enemy)
    {
        switch (enemy.type)
        {
            case Enemy.Enemy_Type.MongSiri:

                enemy.PlayerCollect();
                anim.SetTrigger("Root_MongSiri");
                isAction = true;
                anim.SetBool("isAction", true);
                yield return new WaitForSeconds(1.4f);
                isAction = false;
                anim.SetBool("isAction", false);
                break;

            case Enemy.Enemy_Type.Witch_Flower:

                enemy.PlayerCollect();
                anim.SetTrigger("Root_B");
                isAction = true;
                anim.SetBool("isAction", true);
                SoundManager.Instance.Play_Sound_Effect("Collect_Witch_Flower");
                yield return new WaitForSeconds(1f);
                isAction = false;
                anim.SetBool("isAction", false);
                break;


            case Enemy.Enemy_Type.BushBug:
                enemy.PlayerCollect();
                
                isAction = true;
                anim.SetBool("isAction", true);
                SwingDir(enemy.transform.position);

                StopCoroutine(SwingDeray());
                StartCoroutine(SwingDeray());
                isAction = false;
                anim.SetBool("isAction", false);
                break;

            case Enemy.Enemy_Type.Pumpkin_Dog:

                enemy.PlayerCollect();
                anim.SetTrigger("Root_A");
                isAction = true;
                anim.SetBool("isAction", true);
                SoundManager.Instance.Play_Sound_Effect("Collect_Pumpkin_Dog");
                yield return new WaitForSeconds(1.4f);
                isAction = false;
                anim.SetBool("isAction", false);
                break;

            default:
                enemy.PlayerCollect();
                anim.SetTrigger("Root_A");
                isAction = true;
                anim.SetBool("isAction", true);
                SoundManager.Instance.Play_Sound_Effect("Collect_Branch");
                yield return new WaitForSeconds(0.2f);
                isAction = false;
                anim.SetBool("isAction", false);
                isTree = false;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Woods"))
        {
            if (!SoundManager.Instance.audio_Source_Effects[0].isPlaying)
            {
                SoundManager.Instance.Stop_Sound_Effect("UnderGround_BGM");
                SoundManager.Instance.Play_Sound_BGM("Woods_BGM");
                SoundManager.Instance.Play_Sound_BGM("Bird_BGM");
            }
        }

        if (collision.CompareTag("Under_Ground"))
        {
            if (!SoundManager.Instance.audio_Source_Effects[2].isPlaying)
            {
                SoundManager.Instance.Stop_Sound_Effect("Woods_BGM");
                SoundManager.Instance.Stop_Sound_Effect("Bird_BGM");
                SoundManager.Instance.Play_Sound_BGM("UnderGround_BGM"); 
            }
        }
        if (collision.CompareTag("Witch_Obj_Loster"))
        {
            SoundManager.Instance.Play_Sound_Effect("Witch_Loster_Open"); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        use_Interaction = true;

        if (collision.CompareTag("Enemy"))
        {
            collision_Target = collision;
        }
        if (collision.CompareTag("Escape_Hole"))
        {
            collision_Spawner_Target = collision;
        }
        if (collision.CompareTag("Witch_Obj_Pot"))
        {
            collision_Target = collision;
        }
        if (collision.CompareTag("Witch_Obj_Juicer"))
        {
            collision_Target = collision;
        }  
        if (collision.CompareTag("Witch_Obj_Loster"))
        {
            collision_Target = collision;
        }
        if (collision.CompareTag("NPC"))
        {
            collision_Target = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        use_Interaction = false;
        collision_Target = null;

    }
    
}
