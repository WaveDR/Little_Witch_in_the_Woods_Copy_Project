using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class Potion : ScriptableObject
{
    public enum Potion_Item
    {
        // 잡초제거                   영양공급         햇빛
        potion_Weed_Terminator, potion_Nutrition, potion_Sunlight,
        //부들부들   기침              힐링            저주해제          효자손
        candy_Soft, candy_Cough, candy_Healing, candy_Curse_lifting, candy_Grand_Son

    }

    public Potion_Item item_type;
    
    [SerializeField]private int mixture_IDX = 0;
    public int mixture_index
    {
        get
        {
            switch (item_type)
            {
                case Potion_Item.potion_Weed_Terminator:
                    mixture_IDX = 2401100;
                    break;

                case Potion_Item.potion_Nutrition:
                    mixture_IDX = 3330200;
                    break;

                case Potion_Item.potion_Sunlight:
                    mixture_IDX = 3511100;
                    break;

                case Potion_Item.candy_Soft:
                    mixture_IDX = 1322300;
                    break;

                case Potion_Item.candy_Healing:
                    mixture_IDX = 3411000;
                    break;

                case Potion_Item.candy_Cough:
                    mixture_IDX = 3203400;
                    break;

                case Potion_Item.candy_Curse_lifting:
                    mixture_IDX = 2310100;
                    break;

                case Potion_Item.candy_Grand_Son:
                    mixture_IDX = 2424500;
                    break;
            }

            return mixture_IDX;
        }
         set
        {
          
        }
    }

    
}
