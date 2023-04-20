using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum Root_Item {
        item_Bird_Flower, item_BlueMoonButterfly, item_BushBug, item_OneEyeFrog,
        item_PompomTailFeather, item_PumpkinTerrierFur, item_SmileBurble,
        item_MongSiri_Fur, item_TinkleSpider,

        item_LittleMandrake, item_MapleHerb, item_SilverStarbell,
        item_WetlandGrass, item_WitchFlower, item_Branch, item_Mud, item_Rock_Piece,

        item_Apple, item_Mango
    }

    public Root_Item item_type;
    
    [SerializeField]private int mixture_IDX = 0;
    public int mixture_index
    {
        get
        {
            switch (item_type)
            {
                case Root_Item.item_Bird_Flower:
                    mixture_IDX  = 0;
                    break;

                case Root_Item.item_BlueMoonButterfly:
                    mixture_IDX  = 1;
                    break;

                case Root_Item.item_BushBug:
                    mixture_IDX  = 2;
                    break;

                case Root_Item.item_OneEyeFrog:
                    mixture_IDX  = 3;
                    break;

                case Root_Item.item_PompomTailFeather:
                    mixture_IDX  = 4;
                    break;

                case Root_Item.item_PumpkinTerrierFur:
                    mixture_IDX  = 5;
                    break;

                case Root_Item.item_SmileBurble:
                    mixture_IDX  = 6;
                    break;

                case Root_Item.item_MongSiri_Fur:
                    mixture_IDX  = 7;
                    break;

                case Root_Item.item_TinkleSpider:
                    mixture_IDX  = 8;
                    break;

                case Root_Item.item_LittleMandrake:
                    mixture_IDX  = 9;
                    break;

                case Root_Item.item_MapleHerb:
                    mixture_IDX  = 10;
                    break;

                case Root_Item.item_SilverStarbell:
                    mixture_IDX  = 11;
                    break;

                case Root_Item.item_WetlandGrass:
                    mixture_IDX = 12;
                    break;

                case Root_Item.item_WitchFlower:
                    mixture_IDX = 13;
                    break;

                case Root_Item.item_Branch:
                    mixture_IDX = 14;
                    break;

                case Root_Item.item_Mud:
                    mixture_IDX = 15;
                    break;

                case Root_Item.item_Rock_Piece:
                    mixture_IDX = 16;
                    break;  

                case Root_Item.item_Apple:
                    mixture_IDX = 17;
                    break;  
                case Root_Item.item_Mango:
                    mixture_IDX = 18;
                    break;
            }

            return mixture_IDX;
        }
         set
        {
          
        }
    }

    
}
