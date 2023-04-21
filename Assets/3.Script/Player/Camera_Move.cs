using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    [SerializeField] private Vector2 left_Battom;
    [SerializeField] private Vector2 Top_Right;

    [SerializeField] private Transform target;

    public float moveSpeed;

    [SerializeField] private Player_House house;

    [SerializeField] private Vector3 up_Floor;
    [SerializeField] private Vector3 under_Floor;
   
    // Start is called before the first frame update
    void Awake()
    {
        house = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_House>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (house.camera_chain)
        {
            if (house.under_Ground)
            {
                transform.position = under_Floor;
            }
            
            else 
            {
                transform.position = up_Floor;
            }
        }

        else
        {
            float pos_X = transform.position.x;
            float pos_Y = transform.position.y;
            pos_X = Mathf.Clamp(pos_X, left_Battom.x, Top_Right.x);
            pos_Y = Mathf.Clamp(pos_Y, left_Battom.y, Top_Right.y);

            Vector3 camera_Pos = new Vector3(pos_X, pos_Y, -10); 
            Vector3 target_Pos = new Vector3(target.position.x, target.position.y, this.transform.position.z);
            transform.position = Vector3.Lerp(camera_Pos, target_Pos, moveSpeed * Time.deltaTime);
        }   
    }
}
