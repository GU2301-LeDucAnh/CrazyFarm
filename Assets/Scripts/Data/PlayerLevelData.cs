using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevelData", menuName = "Data/PlayerLevelData", order = 3), Serializable]
public class PlayerLevelData : ScriptableObject
{
    public List<ExpData> lstLevelExp;

    public int GetLastExp()
    {
        for (int i = 0; i < lstLevelExp.Count; i++)
        {
            if (UserProfile.CurrentLevel == lstLevelExp[i].playerLv)
            {
                return lstLevelExp[i].expNeedForNextLv;
            }
        }
        return 0;
    }
}

[Serializable]
public class ExpData
{
    public int playerLv;
    public int expNeedForNextLv;
}
