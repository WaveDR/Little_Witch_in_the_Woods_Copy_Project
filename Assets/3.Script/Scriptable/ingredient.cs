using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class ingredient : ScriptableObject
{
    public enum ingredient_Item
    {
        ingredient_Mongsiri_Origin, ingredient_Silver_Starbell, ingredient_Little_Mandragora, ingredient_Punkin_Terrier_Fur, ingredient_Bird_Flower,

        ingredient_Witch_Flower, ingredient_Tinkle_Spider, ingredient_Smile_Bubble, ingredient_One_Eye_Flog,

        ingredient_Maple_Hube, ingredient_Bush_Bug
    }

    public ingredient_Item item_type;
    
    [SerializeField]private int mixture_IDX = 0;
    public int mixture_index
    {
        get
        {
            switch (item_type)
            {
                case ingredient_Item.ingredient_Mongsiri_Origin:
                    mixture_IDX  = 100;
                    break;

                case ingredient_Item.ingredient_Silver_Starbell:
                    mixture_IDX  = 200;
                    break;

                case ingredient_Item.ingredient_Little_Mandragora:
                    mixture_IDX  = 300;
                    break;

                case ingredient_Item.ingredient_Punkin_Terrier_Fur:
                    mixture_IDX  = 400;
                    break;

                case ingredient_Item.ingredient_Bird_Flower:
                    mixture_IDX  = 500;
                    break;

                case ingredient_Item.ingredient_Witch_Flower:
                    mixture_IDX  = 1000;
                    break;

                case ingredient_Item.ingredient_Tinkle_Spider:
                    mixture_IDX  = 2000;
                    break;

                case ingredient_Item.ingredient_Smile_Bubble:
                    mixture_IDX  = 3000;
                    break;

                case ingredient_Item.ingredient_One_Eye_Flog:
                    mixture_IDX  = 4000;
                    break;

                case ingredient_Item.ingredient_Maple_Hube:
                    mixture_IDX  = 10000;
                    break;

                case ingredient_Item.ingredient_Bush_Bug:
                    mixture_IDX  = 20000;
                    break;
            }

            return mixture_IDX;
        }
         set
        {
          
        }
    }

    
}
