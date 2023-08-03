using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private GameObject lockGO;
    [SerializeField] private TextMeshProUGUI coinSpentTxt;
    [SerializeField] private TextMeshProUGUI playerLvCanUlock;
    [SerializeField] private TextMeshProUGUI rewardCoinTxt;
    [SerializeField] private TextMeshProUGUI rewardExpTxt;
    [SerializeField] private Button btnBuy;

    private PlantInfo plantInfo;
    public void Init(PlantInfo plantInfo)
    {
        this.imgIcon.sprite = plantInfo.iconPlant;
        this.coinSpentTxt.text = plantInfo.coinSpent.ToString();
        this.playerLvCanUlock.text = plantInfo.playerLvCanUlock.ToString();
        this.rewardCoinTxt.text = plantInfo.rewards.coinCollect.ToString();
        this.rewardExpTxt.text = plantInfo.rewards.expCollect.ToString();
        this.plantInfo = plantInfo;

        CheckCanBuy(plantInfo.playerLvCanUlock);
    }

    void CheckCanBuy(int playerLvCanUlock)
    {
        btnBuy.onClick.RemoveAllListeners();
        if (UserProfile.CurrentLevel >= playerLvCanUlock)
        {
            lockGO.gameObject.SetActive(false);
            btnBuy.gameObject.SetActive(true);
            coinSpentTxt.gameObject.SetActive(true);
            rewardCoinTxt.gameObject.SetActive(true);
            rewardExpTxt.gameObject.SetActive(true);
            btnBuy.onClick.AddListener(SelectPlant);
        }
        else
        {
            lockGO.gameObject.SetActive(true);
            btnBuy.gameObject.SetActive(false);
            coinSpentTxt.gameObject.SetActive(false);
            rewardCoinTxt.gameObject.SetActive(false);
            rewardExpTxt.gameObject.SetActive(false);
        }
    }

    void SelectPlant()
    {
        GamePlayController.Instance.selectedPlant = this.plantInfo;
    }
}
