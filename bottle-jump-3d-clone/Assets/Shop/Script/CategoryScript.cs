using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MagneticScrollView;
public class CategoryScript : MonoBehaviour
{
    public string CategoryName;
    public Text DesCriptionText;
    public List<string> CategoryPageName;
    public GameObject[] AllitemsList;
    public Transform PurchasedButton;
    public Image SelectedImage;
    public Color selected, canSelect, none;
    public MagneticScrollRect magneticScript;

    [Header("Can Skip")]
    public BoolArray PurchaseIndexList;
    public int currentIndex;
    public int currentPage;
    [Header("For Random Purchase")]
    public int[] ItemCountPerPage;
    public bool isRandom;
    public int RandomItemPrice;
   // public int[] itemPriceList;

    List<int> UnpurchaseCurrentPage;
    public static CategoryScript instance;
    private void Awake()
    {
        instance = this;
        Init();
    }
    void Start()
    {
        ButtonCheck();
    }
    void Init()
    {
        if (!PlayerPrefs.HasKey(CategoryName))
        {
            SaveBoolArray(CategoryName, PurchaseIndexList);
        }
        else
        {
            PurchaseIndexList = LoadBoolArray(CategoryName);
        }
        for (int i = 0; i < AllitemsList.Length; i++)
        {
            //Allready Purchased
            if (PurchaseIndexList.bools[i])
            {
                AllitemsList[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                AllitemsList[i].transform.GetChild(1).gameObject.SetActive(true);
            }

            
        }
        if (isRandom)
        {
            itemButtonColor(currentIndex, selected, true);
        }
        else
        {
            if (PlayerPrefs.HasKey(CategoryName + "currentIndex"))
            {
                currentIndex = PlayerPrefs.GetInt(CategoryName + "currentIndex");
                itemButtonClicked(currentIndex);
            }
            else
            {
                itemButtonClicked(0);
            }
        }
        
        
    }

    public void SelectionPageChange()
    {
        currentPage=magneticScript.CurrentSelectedIndex;
        Debug.Log("Page Change:" + currentPage);
        DesCriptionText.text = CategoryPageName[currentPage];
        UpdateUnpurchaseList();
    }
    void ButtonCheck()
    {
        if (CoinManager.instance.TotalCoin >= RandomItemPrice)
        {
            PurchasedButton.GetComponent<Button>().interactable=true;
        }
        else
        {
            PurchasedButton.GetComponent<Button>().interactable = false;
        }
    }
    void UpdateUnpurchaseList()
    {
        //List Update
        ButtonCheck();
        UnpurchaseCurrentPage = new List<int>();
        currentPage = magneticScript.CurrentSelectedIndex;
        int start = 0, end = 0;
        for (int i = 0; i < ItemCountPerPage.Length; i++)
        {
            if (i < currentPage)
            {
                start += ItemCountPerPage[i];
            }
            if(i<=currentPage)
            {
                end += ItemCountPerPage[i];
            }
        }
        for (int i = start; i < end; i++)
        {
            if (!PurchaseIndexList.bools[i])
            {
                UnpurchaseCurrentPage.Add(i);
                AllitemsList[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void itemButtonClicked(int index)
    {
        ////if (isRandom)
        ////{
        ////    return;
        ////}
        //Already Purchased
        if (PurchaseIndexList.bools[index])
        {
            //PurchasedButton.GetChild(0).gameObject.SetActive(false);
            //PurchasedButton.GetChild(1).gameObject.SetActive(false);
            //PurchasedButton.GetChild(2).gameObject.SetActive(true);
            SelectedImage.sprite = AllitemsList[index].transform.GetChild(0).GetChild(0).GetComponent <Image>().sprite;
            itemButtonColor(index, selected, true);
            currentIndex = index;
            PlayerPrefs.SetInt(CategoryName + "currentIndex", currentIndex);
        }
       //else //Not Purchased
       // {
       //     PurchasedButton.GetChild(0).gameObject.SetActive(true);
       //     PurchasedButton.GetChild(1).gameObject.SetActive(true);
       //     PurchasedButton.GetChild(2).gameObject.SetActive(false);

       //     PurchasedButton.GetChild(0).GetComponent<Text>().text = itemPriceList[index].ToString();

       //     itemButtonColor(index, canSelect, false);

       // }

    }
    void itemButtonColor(int index,Color c,bool flag)
    {
        if (flag)
        {
            for (int i = 0; i < AllitemsList.Length; i++)
            {
                if (index == i)
                {
                    AllitemsList[i].GetComponent<Image>().color = selected;
                }
                else
                {
                    AllitemsList[i].GetComponent<Image>().color = none;
                }
            }
        }
        else
        {
            for (int i = 0; i < AllitemsList.Length; i++)
            {
                if (index == currentIndex)
                {
                    AllitemsList[i].GetComponent<Image>().color = selected;
                }
                else if (index == i)
                {
                    AllitemsList[i].GetComponent<Image>().color = canSelect;
                }
                else
                {
                    AllitemsList[i].GetComponent<Image>().color = none;
                }
            }
        }
        
    }
    public void OnClickPurchase()
    {
        if(CoinManager.instance.TotalCoin<RandomItemPrice)
        {
            return;
        }
        //Check Valid For Purchase
        if (UnpurchaseCurrentPage.Count > 1)
        {
            StartCoroutine(RandomSelection());
        }
        


    }

    IEnumerator RandomSelection()
    {
        int pre=50; 
        for(int round=0; round<10;)
        {
            int r =Random.Range(0, UnpurchaseCurrentPage.Count);
            GameObject current = AllitemsList[UnpurchaseCurrentPage[r]];
            current.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
            
            if (pre !=50)
            {
                UnpurchaseCurrentPage.Add(pre);
            }

            pre = UnpurchaseCurrentPage[r];
            round++;
            if (round < 10)
            {
                UnpurchaseCurrentPage.Remove(pre);
                current.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(.1f);
        //item Purchased
        ItemPurchase(pre);
    }
    void ItemPurchase(int itemNO)
    {
        CoinManager.instance.RemoveCoin(RandomItemPrice);
        GameObject current= AllitemsList[itemNO];
        current.transform.GetChild(1).gameObject.SetActive(false);
        current.transform.GetChild(2).gameObject.SetActive(false);
        PurchaseIndexList.bools[itemNO] = true;
        PlayerPrefs.SetInt(CategoryName + "currentIndex",itemNO);
        SaveBoolArray(CategoryName, PurchaseIndexList);
        UpdateUnpurchaseList();
    }

    //Save and Load from Json
    #region

    void SaveBoolArray(string key, BoolArray boolArray)
    {
        var str = JsonUtility.ToJson(boolArray);
        PlayerPrefs.SetString(key, str);
    }
    BoolArray LoadBoolArray(string key)
    {
        var str = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<BoolArray>(str);
    }

    [System.Serializable]
    public class BoolArray
    { 
        public List<bool> bools = new List<bool>();
    };
    #endregion

}
