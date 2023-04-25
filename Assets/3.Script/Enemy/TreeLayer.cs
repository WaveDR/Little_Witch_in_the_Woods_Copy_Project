using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TreeLayer : MonoBehaviour

{

    TilemapRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = Mathf.RoundToInt(transform.localPosition.y) * -1;
    }
}
