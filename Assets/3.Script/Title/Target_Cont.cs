using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target_Cont : MonoBehaviour
{

    public float arrow_Move;
    private float arrow_PosY;
    private float arrow_PosX;

    [SerializeField] private RectTransform chooise_Arrow;
    [SerializeField] private int arrow_Move_Max;
    [SerializeField] private int arrow_Move_Min;

    public AudioSource audio;

    public GameObject keybord;
    bool issKeybord;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio_Start").GetComponent<AudioSource>();
        arrow_PosX = chooise_Arrow.anchoredPosition.x;
        arrow_PosY = chooise_Arrow.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Arrow_Move();
        Arrow_choice();
    }

    void Arrow_Move()
    {
        arrow_PosY = Mathf.Clamp(arrow_PosY, arrow_Move_Min, arrow_Move_Max);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrow_PosY += arrow_Move;

            if (arrow_PosY <= arrow_Move_Max)
            {
                chooise_Arrow.anchoredPosition = new Vector3(arrow_PosX, arrow_PosY);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrow_PosY -= arrow_Move;

            if (arrow_PosY >= arrow_Move_Min)
            {
                chooise_Arrow.anchoredPosition = new Vector3(arrow_PosX, arrow_PosY);
            }
        }
    }
    void Arrow_choice()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (arrow_PosY)
            {
                case -90:
                    StartCoroutine(Start_Co());
                    break;
                case -220:
                    keybord.SetActive(true);
                    issKeybord = true;
                    break;
                case -350:
                    Application.Quit();
                    break;
            }
        }
        if (issKeybord)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                keybord.SetActive(false);
                issKeybord = false;
            }
        }
    }
    IEnumerator Start_Co()
    {
        audio.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Tutorial_Scene");
    }
}
