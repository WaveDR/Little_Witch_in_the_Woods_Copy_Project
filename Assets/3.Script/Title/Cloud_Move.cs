using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Move : MonoBehaviour
{
    public float speed;
    private float yPos;

    [SerializeField]
    private float minPos;
    [SerializeField]
    private float maxPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= minPos)
        {

            if (gameObject.tag == "Cloud")
            {
                yPos = Random.Range(0, 2);
            }
            else
            {
                yPos = transform.position.y;
            }
        
            transform.position = new Vector3(maxPos, yPos, 0);
        }
    }
}
