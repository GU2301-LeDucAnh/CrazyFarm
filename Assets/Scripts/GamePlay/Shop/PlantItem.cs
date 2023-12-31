using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlantItem : ShopItem
{
    private PlantInfo plantInfo;
    [SerializeField] private Image iconItem;
    public void Init(PlantInfo plantInfo)
    {
        this.plantInfo = plantInfo;
        curBtn = GetComponent<Button>();
        curBtn.targetGraphic.GetComponent<Image>().sprite = normalImg;
        iconItem.sprite = plantInfo.iconPlant;
        curBtn.onClick.AddListener(ChangeInfo);
        if (plantInfo.idPlant == 0)
        {
            curBtn.Select();
            ChangeInfo();
        }
    }

    public override void ChangeInfo()
    {
        ShopController.Setup().itemInfo.Init(plantInfo);
    }
}
