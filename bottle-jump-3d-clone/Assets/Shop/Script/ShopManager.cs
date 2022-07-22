using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public CategoryScript[] AllCategories;
    public Image[] AllCatoriesTab;
    public Text NameTxt;
    public Color SelectColor, UnSelectColor;
    private void Awake()
    {
        instance = this;
    }

    public void CategoryTabClick(int index)
    {
        for (int i = 0; i < AllCategories.Length; i++)
        {
            if (i == index)
            {
                AllCategories[i].gameObject.SetActive(true);
                AllCatoriesTab[i].color = SelectColor;
            }
            else
            {
                AllCategories[i].gameObject.SetActive(false);
                AllCatoriesTab[i].color = UnSelectColor;
            }
        }
    }
    public void CloseShopPanel()
    {

    }


}
