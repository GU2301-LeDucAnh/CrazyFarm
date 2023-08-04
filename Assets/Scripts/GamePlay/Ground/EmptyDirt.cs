using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class EmptyDirt : MonoBehaviour
{
    public int id;
    public DirtState dirtState;

    private GameObject curPlantGO;
    private PlantInfo curPlantInfo;
    private DateTime timeToHavert;

    private bool isCanClaim;

    public bool IsCanClaim
    {
        get
        {
            return isCanClaim;
        }
        set
        {
            isCanClaim = value;
        }
    }

    public void Init()
    {
        
    }

    public void PlantingPlant(PlantInfo plantInfo)
    {
        curPlantInfo = plantInfo;
        if (dirtState != DirtState.EmptyDirt || UserProfile.CurrentCoin < plantInfo.coinSpent)
            return;

        UserProfile.CurrentCoin -= plantInfo.coinSpent;
        GamePlayController.Instance.gameScene.ChangTxtCoin();
        dirtState = DirtState.HasPlant;
        GameObject plantOnDirt = Instantiate(plantInfo.smallPlant, gameObject.transform);

        SaveDirt(plantOnDirt);

        StartCoroutine(CurPlantUpdate());
    }

    private void SaveDirt(GameObject curPlant)
    {
        this.curPlantGO = curPlant;
        timeToHavert = CalculatorTimeHavert(curPlantInfo);
    }

    private DateTime CalculatorTimeHavert(PlantInfo plantInfo)
    {
        double temp = plantInfo.timeToHarvest;
        DateTime curTime = UnbiasedTime.Instance.Now();
        DateTime different = curTime.AddMinutes(temp);
        return different;
    }

    private IEnumerator CurPlantUpdate()
    {
        if (curPlantInfo.smallPlant.name + "(Clone)" == curPlantGO.name)
        {
            while(UnbiasedTime.Instance.Now() <= timeToHavert.AddMinutes(-(double)(curPlantInfo.timeToHarvest / 2)))
            {
                yield return new WaitForSeconds(1);
            }
            Destroy(curPlantGO);
            GameObject plantOnDirt = Instantiate(curPlantInfo.mediumPlant, gameObject.transform);
            curPlantGO = plantOnDirt;
            StartCoroutine(CurPlantUpdate());
        }
        else if (curPlantInfo.mediumPlant.name + "(Clone)" == curPlantGO.name)
        {
            while (UnbiasedTime.Instance.Now() <= timeToHavert)
            {
                yield return new WaitForSeconds(1);
            }
            Destroy(curPlantGO);
            GameObject plantOnDirt = Instantiate(curPlantInfo.bigPlant, gameObject.transform);
            curPlantGO = plantOnDirt;
            StartCoroutine(CurPlantUpdate());
        }
        else
        {
            isCanClaim = true;
        }
    }

    public void CanClaim()
    {
        UserProfile.CurrentCoin += curPlantInfo.rewards.coinCollect;
        UserProfile.CurrentExp += curPlantInfo.rewards.expCollect;
        UserProfile.CurrentPlantCollection += curPlantInfo.rewards.plantCollect;

        StartCoroutine(GameController.Instance.playerProfile.CheckExpForNextLv());

        Destroy(curPlantGO);
        dirtState = DirtState.EmptyDirt;
        curPlantGO = null;
        curPlantInfo = null;

        isCanClaim = false;
    }
}

[System.Serializable]
public class SavedDirtData
{
    public Transform transform;

    public int dirtId;
    public PlantInfo plantInfo;
    public long timePlant;
}

public enum DirtState
{
    EmptyDirt,
    HasPlant,
}
