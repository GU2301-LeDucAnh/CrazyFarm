using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [HideInInspector] public string playerName;
    [HideInInspector] public int levelPlayer;

    public void Init(/*FirebaseManager firebaseManager*/)
    {
        //PlayerProfile playerProfile = new PlayerProfile();
        playerName = UserProfile.PlayerName;
        levelPlayer = UserProfile.CurrentLevel;
        //firebaseManager.SendPlayerProfile(playerProfile);
    }

    public IEnumerator CheckExpForNextLv()
    {
        yield return new WaitForEndOfFrame();

        var playerLevelData = GameController.Instance.dataManager.playerLevelData;
        int lastExp = playerLevelData.GetLastExp();

        GamePlayController.Instance.gameScene.ChangeTxtPlayerLv(lastExp);
        GamePlayController.Instance.gameScene.ChangTxtCoin();
        GamePlayController.Instance.gameScene.ChangeTxtCollection();
    }
}
