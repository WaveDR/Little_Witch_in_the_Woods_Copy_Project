using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    [SerializeField] private Vector2 left_Battom;
    [SerializeField] private Vector2 Top_Right;

    [SerializeField] private Transform target;

    public float moveSpeed;
   
    // Start is called before the first frame update
    void Awake()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_Pos = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target_Pos, moveSpeed * Time.deltaTime);
        
    }
}
