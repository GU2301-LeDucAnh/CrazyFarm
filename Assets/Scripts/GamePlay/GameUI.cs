using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameUI : MonoBehaviour
{
    public Button attachBtn;
    public Button shopBtn;
    public TextMeshProUGUI txtAttachBtn;
    public TextMeshProUGUI playerName;
    public Image curExp;
    public TextMeshProUGUI playerLv;
    public TextMeshProUGUI coinTxt;
    public Button collectionBtn;
    public GameObject collectionPanel;
    public TextMeshProUGUI txtPlantCollection;
    public TextMeshProUGUI txtTreeCollection;


    //public Text notificationText;
    //public GameObject rewardObject;
    //public Camera mainCamera;

    //private bool isWithinScreen = false;

    //void Start()
    //{
    //    StartCoroutine(CheckUIPosition());
    //}

    //IEnumerator CheckUIPosition()
    //{
    //    while (true)
    //    {
    //        Vector3 worldPosition = transform.position;

    //        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

    //        isWithinScreen = IsInScreen(screenPosition);

    //        if (isWithinScreen)
    //        {
    //            rewardObject.SetActive(true);
    //        }
    //        else
    //        {
    //            rewardObject.SetActive(false);
    //        }
    //        yield return new WaitForSeconds(1f);
    //    }
    //}

    //bool IsInScreen(Vector3 screenPosition)
    //{
    //    return screenPosition.x >= 0 && screenPosition.x <= Screen.width &&
    //           screenPosition.y >= 0 && screenPosition.y <= Screen.height;
    //}

    public void Init()
    {
        playerName.text = UserProfile.PlayerName;
        ChangeTxtPlayerLv(GameController.Instance.dataManager.playerLevelData.GetLastExp());
        ChangTxtCoin();
        ChangeTxtCollection();

        collectionPanel.SetActive(false);
        collectionBtn.onClick.RemoveAllListeners();
        collectionBtn.onClick.AddListener(ChangeCollectionTab);
    }

    public void ChangeTxtCollection()
    {
        txtPlantCollection.text = UserProfile.CurrentPlantCollection.ToString();
        txtTreeCollection.text = UserProfile.CurrentTreeCollection.ToString();
    }

    public void ChangeCollectionTab()
    {
        if (collectionPanel.activeInHierarchy == false)
        {
            collectionPanel.SetActive(true);
            collectionPanel.transform.DOMoveY(collectionPanel.transform.position.y + 200, 1);
            collectionBtn.transform.DOMoveY(collectionBtn.transform.position.y + 200, 1);
            collectionBtn.gameObject.transform.DORotate(new Vector3(0, 0, collectionBtn.gameObject.transform.localRotation.z + 180), 1);
            collectionBtn.onClick.RemoveAllListeners();
            collectionBtn.onClick.AddListener(ChangeCollectionTab);
        }
        else
        {
            collectionPanel.transform.DOMoveY(collectionPanel.transform.position.y - 200, 1).OnComplete(
                () => {
                collectionPanel.SetActive(false);
            });
            collectionBtn.transform.DOMoveY(collectionBtn.transform.position.y - 200, 1);
            collectionBtn.gameObject.transform.DORotate(new Vector3(0, 0, collectionBtn.gameObject.transform.localRotation.z + 180), 1);
            collectionBtn.onClick.RemoveAllListeners();
            collectionBtn.onClick.AddListener(ChangeCollectionTab);
        }
    }

    public void ChangeTxtPlayerLv(int lastExp)
    {
        playerLv.text = UserProfile.CurrentLevel.ToString();
        curExp.fillAmount = (float) UserProfile.CurrentExp / (float) lastExp;
    }

    public void ChangTxtCoin()
    {
        coinTxt.text = UserProfile.CurrentCoin.ToString();
    }
}
