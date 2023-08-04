using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TabPlant tabPlant;
    [SerializeField] private ShopItem shopElement;
    [SerializeField] private GameObject scrollViewContentShop;
    [SerializeField] private Button closeBtn;
    public ItemInfo itemInfo;

    public static ShopController Instance;

    public List<PlantItem> lstBtnSelectPlant = new List<PlantItem>();
    private List<PlayerSkinItem> lstBtnSelectPlayerSkin;

    public static ShopController Setup()
    {
        if (Instance == null)
        {
            Instance = Instantiate(Resources.Load(PathPrefab.SHOP_CANVAS) as GameObject).GetComponent<ShopController>();
        }
        return Instance;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        tabPlant.ShowTab();
        tabPlant.btnTab.onClick.Invoke();
        closeBtn.onClick.AddListener(ClosePanel);
    }

    public void PlantShowTab()
    {
        var lstPlant = GameController.Instance.dataManager.plantData.lstPlant;
        for (int i = 0; i < lstPlant.Count; i++)
        {
            var btnSelectPlant = Instantiate(tabPlant.plantElement.gameObject, scrollViewContentShop.transform).GetComponent<PlantItem>();
            lstBtnSelectPlant.Add(btnSelectPlant);
            btnSelectPlant.Init(lstPlant[i]);
        }
        tabPlant.btnTab.onClick.RemoveAllListeners();
    }

    public void PlantHideTab()
    {
        foreach (PlantItem btnPlant in lstBtnSelectPlant)
        {
            Destroy(btnPlant.gameObject);
        }
        StartCoroutine(enumerator());
        tabPlant.btnTab.onClick.RemoveAllListeners();
    }

    IEnumerator enumerator()
    {
        yield return new WaitForEndOfFrame();
        lstBtnSelectPlant.RemoveAll(item => item == null);
    }

    public void PlayerSkinShowTab()
    {
        //var lstSkin = GameController.Instance.dataManager.skinData.skins;
        //for (int i = 0; i < lstSkin.Count; i++)
        //{
        //    var btnSelectPlayerSkin = Instantiate(shopElement.gameObject, scrollViewContentShop.transform).GetComponent<PlayerSkinItem>();
        //    btnSelectPlayerSkin.Init(lstSkin[i]);
        //    lstBtnSelectPlayerSkin.Add(btnSelectPlayerSkin);
        //}
        //PlantHideTab();
    }

    public void PlayerSkinHideTab()
    {
        //for (int i = 0; i < lstBtnSelectPlayerSkin.Count; i++)
        //{
        //    Destroy(lstBtnSelectPlayerSkin[i]);
        //    lstBtnSelectPlayerSkin.Remove(lstBtnSelectPlayerSkin[i]);
        //}
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        tabPlant.btnTab.onClick.AddListener(tabPlant.HideTab);
    }
}

[System.Serializable]
public class TabController
{
    public TabPlant tabPlant;
    public TabPlayerSkin tabPlayerSkin;
}

[System.Serializable]
public class TabBtn
{
    public Button btnTab;
    public virtual void ShowTab()
    {

    }

    public virtual void HideTab()
    {

    }
}

[System.Serializable]
public class TabPlant : TabBtn
{
    public PlantItem plantElement;
    public override void ShowTab()
    {
        btnTab.onClick.AddListener(ShopController.Instance.PlantShowTab);
    }

    public override void HideTab()
    {
        ShopController.Instance.PlantHideTab();
    }
}

[System.Serializable]
public class TabPlayerSkin : TabBtn
{
    public override void ShowTab()
    {
        //btnTab.onClick.AddListener(ShopController.Instance.PlayerSkinShowTab);
    }

    public override void HideTab()
    {
        //ShopController.Instance.PlayerSkinHideTab();
    }
}
