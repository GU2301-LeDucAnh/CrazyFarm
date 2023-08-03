using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeElement : MonoBehaviour
{
    public int id;
    //public GameObject uICanCollect;

    private TreeInfo treeInfo;
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

    public void InitState()
    {
        foreach (TreeInfo treeInfo in GameController.Instance.dataManager.treeData.lstTree)
        {
            if (this.id == treeInfo.idTree)
            {
                this.treeInfo = treeInfo;
            }
        }
        timeToHavert = CalculatorTimeHavert(treeInfo);
        //uICanCollect.SetActive(false);
        StartCoroutine(ClaimTree());
    }

    private DateTime CalculatorTimeHavert(TreeInfo treeInfo)
    {
        double temp = treeInfo.timeToHarvest;
        DateTime curTime = UnbiasedTime.Instance.Now();
        DateTime different = curTime.AddMinutes(temp);
        return different;
    }

    private IEnumerator ClaimTree()
    {
        Debug.LogError(timeToHavert.ToString());
        if (UnbiasedTime.Instance.Now() <= timeToHavert)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(ClaimTree());
        }
        else
        {
            isCanClaim = true;
            Debug.LogError(IsCanClaim);
        }
        //uICanCollect.SetActive(true);
    }

    public void CanClaim()
    {
        UserProfile.CurrentCoin += treeInfo.rewards.coinCollect;
        UserProfile.CurrentExp += treeInfo.rewards.expCollect;
        UserProfile.CurrentTreeCollection += treeInfo.rewards.treeCollect;

        GamePlayController.Instance.gameScene.ChangeTxtPlayerLv();
        GamePlayController.Instance.gameScene.ChangTxtCoin();
        GamePlayController.Instance.gameScene.ChangeTxtCollection();

        //uICanCollect.SetActive(false);
        isCanClaim = false;
        InitState();
        Debug.LogError(IsCanClaim);
    }
}
