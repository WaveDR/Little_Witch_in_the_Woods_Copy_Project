using UnityEngine;

public class Player_House : MonoBehaviour
{
    [SerializeField] private Transform Door_Pos;
    [SerializeField] private Transform House_Pos;
    [SerializeField] private Transform Under_Pos;


    Player player;
    public bool camera_chain = false;

    //ÁöÇÏ½Ç 
    public bool under_Ground = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Witch_House_Door"))
        {
            camera_chain = true;
            Game_UI_Manager.Instance.anim.SetTrigger("FadeOut");
            transform.position = new Vector3(House_Pos.position.x, House_Pos.position.y);
        }

        if (collision.CompareTag("Witch_House_In_Door"))
        {
            camera_chain = false;
            Game_UI_Manager.Instance.anim.SetTrigger("FadeOut");
            transform.position = new Vector3(Door_Pos.position.x, Door_Pos.position.y);
        }

        if (collision.CompareTag("Witch_House_Elevaiter"))
        {
            under_Ground = true;
            Game_UI_Manager.Instance.anim.SetTrigger("FadeOut");
            transform.position = new Vector3(Under_Pos.position.x, Under_Pos.position.y);
        }
        if (collision.CompareTag("Witch_House_Elevaiter_Under"))
        {
            under_Ground = false;  
            Game_UI_Manager.Instance.anim.SetTrigger("FadeOut");
            transform.position = new Vector3(House_Pos.position.x, House_Pos.position.y);
        }
    }

}
