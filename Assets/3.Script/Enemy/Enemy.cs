using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Item item_Data;
    [SerializeField] private GameObject escape_Hole;

    public enum Enemy_Type { MongSiri, Witch_Flower, Branch, Cranapple, BushBug, Pumpkin_Dog };
    public Enemy_Type type;

    public enum Fauna_Flora_Type { Creature, Plant };
    public Fauna_Flora_Type fauna_type;

    public Enemy_Spawner enemySpawn;
    public Animator anim;
    public Player player;
    public SpriteRenderer sprite;
    private Vector2 Move_Point;

    private float enemy_MoveSpeed;
    private float move_Time;

    public bool isCollect;
    public bool isLookAt;

    private bool isMove;
    private bool isPlayer_Lookat;
    private bool isHunt;
    private bool isCreature;


    private CircleCollider2D circle;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isHunt = false;
        isMove = true;

        switch (fauna_type)
        {
            case Fauna_Flora_Type.Creature:

                TryGetComponent(out anim);
                TryGetComponent(out sprite);
                TryGetComponent(out circle);
                enemySpawn = GetComponentInParent<Enemy_Spawner>();
                isPlayer_Lookat = false;
                enemy_MoveSpeed = speed;
                isCreature = true;
                break;

            case Fauna_Flora_Type.Plant:
                enemy_MoveSpeed = 0;
                isCreature = false;
                break;
        }
    }
    private void OnEnable()
    {
        if (isCreature)
        {
            if(type == Enemy_Type.MongSiri)
            {
                circle.enabled = true;
                isPlayer_Lookat = false;
                anim.SetBool("Escape_Sucess", false);
            }
        }
        isLookAt = false;
        isHunt = false;
        isCollect = false;
    }

    private void Update()
    {
        if (isCreature && type == Enemy_Type.MongSiri)
        {
            if (!isPlayer_Lookat)
            {
                transform.position = Vector3.MoveTowards(transform.position, Move_Point, enemy_MoveSpeed * Time.deltaTime);
            }
            if (isMove)
            {
                Move_Enemy();
            }


            if (isLookAt)
            {
                Enemy_Lookat();
            }
            else if (!isLookAt)
            {
                Enemy_Lookat_Out();
            }
        }
    }
    void Move_Enemy()
    {
        isMove = false;
        float randPos_X = Random.Range(-1, 1f);
        float randPos_Y = Random.Range(-1, 1f);

        if (!isCollect)
        {

            if (isHunt)
            {
                Move_Point = new Vector2(transform.position.x, transform.position.y + 1.5f);
            }
            if (!isHunt)
            {
                Move_Point = new Vector3(transform.position.x + randPos_X, transform.position.y + randPos_Y, 0).normalized;
            }
        }


        StartCoroutine(MoveAnimation(randPos_X, randPos_Y));
        StartCoroutine(IsMove_Change());

    }
    IEnumerator IsMove_Change()
    {
        move_Time = Random.Range(3f, 4f);
        WaitForSeconds move = new WaitForSeconds(move_Time);

        yield return move;
        isMove = true;
    }
    IEnumerator MoveAnimation(float posX, float posY)
    {
        anim.SetBool("isMove", true);
        anim.SetFloat("MoveX", posX);
        anim.SetFloat("MoveY", posY);


        if (posX > transform.position.x)
        {
            sprite.flipX = true;
        }
        if (posX < transform.position.x)
        {
            sprite.flipX = false;
        }


        yield return new WaitForSeconds(0.3f);

        anim.SetBool("isMove", false);
    }
    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //  
    //     if (collision.CompareTag("Player"))
    //     {
    //         if (!isHunt)
    //         {
    //             isPlayer_Lookat = true;
    //
    //             if (transform.position.x < player.transform.position.x)
    //             {
    //                 sprite.flipX = true;
    //             }
    //             if (transform.position.x > player.transform.position.x)
    //             {
    //                 sprite.flipX = false;
    //             }
    //         }
    //         anim.SetBool("PlayerSearch", isPlayer_Lookat);
    //     }
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         isPlayer_Lookat = false;
    //         sprite.flipX = false;
    //         anim.SetBool("PlayerSearch", isPlayer_Lookat);
    //     }
    // }


    public void Enemy_Lookat()
    {
        isPlayer_Lookat = true;


        if (!isCollect)
        {
            if (transform.position.x < player.transform.position.x)
            {
                sprite.flipX = true;
            }
            if (transform.position.x > player.transform.position.x)
            {
                sprite.flipX = false;
            }
        }


        anim.SetBool("PlayerSearch", isPlayer_Lookat);
    }
    public void Enemy_Lookat_Out()
    {
        isPlayer_Lookat = false;

        sprite.flipX = false;

        anim.SetBool("PlayerSearch", isPlayer_Lookat);

        if (isCollect)
        {
            if (0 > transform.localPosition.x)
            {
                sprite.flipX = true;
            }
            if (0 < transform.localPosition.x)
            {
                sprite.flipX = false;
            }
        }
    }


    //플레이어 컬렉트 상호작용 데이터 전해주기
    public void PlayerCollect()
    {
        StopCoroutine(Enemy_Rooting_Motion());
        StartCoroutine(Enemy_Rooting_Motion());
    }

    IEnumerator Enemy_Rooting_Motion()
    {
        switch (type)
        {
            case Enemy_Type.MongSiri:

                isHunt = true;
                Inventory_Manager.Instance.item_Index.Add(item_Data.mixture_index);
                Inventory_Manager.Instance.Update_Item_Idx();
                enemy_MoveSpeed = 0;
                anim.SetTrigger("Enemy_Hunt");
                yield return new WaitForSeconds(1.5f);
                isHunt = false;
                isCollect = true;

                break;

            case Enemy_Type.Witch_Flower:

                Inventory_Manager.Instance.item_Index.Add(item_Data.mixture_index);
                Inventory_Manager.Instance.Update_Item_Idx();
                anim.SetBool("Plant_Collect", true);
                yield return new WaitForSeconds(1.2f);
                gameObject.SetActive(false);
                break;


            case Enemy_Type.BushBug:
                Inventory_Manager.Instance.item_Index.Add(item_Data.mixture_index);
                Inventory_Manager.Instance.Update_Item_Idx();
                yield return new WaitForSeconds(1f);
                gameObject.SetActive(false);
                break;

            case Enemy_Type.Pumpkin_Dog:

                isHunt = true;
                Inventory_Manager.Instance.item_Index.Add(item_Data.mixture_index);
                Inventory_Manager.Instance.Update_Item_Idx();
                enemy_MoveSpeed = 0;
                anim.SetTrigger("Enemy_Hunt");
                yield return new WaitForSeconds(1.5f);
                gameObject.SetActive(false);
                isHunt = false;
                isCollect = true;

                break;


            default:
                Inventory_Manager.Instance.item_Index.Add(item_Data.mixture_index);
                Inventory_Manager.Instance.Update_Item_Idx();
                yield return new WaitForSeconds(0.2f);
                gameObject.SetActive(false);
                break;
        }
    }
    IEnumerator Enemy_Escape()
    {
        circle.enabled = false;
        enemy_MoveSpeed = speed;
        Vector2 curPos = transform.position;
        Move_Point = new Vector2(transform.parent.position.x, transform.parent.position.y);

        if (curPos == Move_Point)
        {
            anim.SetBool("Escape_Sucess", true);
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}
