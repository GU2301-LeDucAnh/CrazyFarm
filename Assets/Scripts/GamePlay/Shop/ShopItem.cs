using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Sprite normalImg;
    public Sprite selectedImg;
    [HideInInspector] public Button curBtn;

    public virtual void ChangeInfo()
    {

    }
}

public class PlayerSkinItem : ShopItem
{
    public void Init(SkinInfo skinInfo)
    {
        var iconImg = Instantiate(skinInfo.iconSkin);
        curBtn.onClick.AddListener(ChangeInfo);
    }
    public override void ChangeInfo()
    {

    }
}
