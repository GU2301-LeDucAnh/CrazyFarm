using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance;
    public GameUI gameScene;
    public ParticleController particleController;
    public GroundController groundController;
    public TreeController treeController;

    public PlayerController playerController;
    [HideInInspector] public PlantInfo selectedPlant;
    void Awake()
    {
        Instance = this;
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        gameScene.Init();
        groundController.Init();
        treeController.Init();
        selectedPlant = null;
        gameScene.attachBtn.gameObject.SetActive(false);
        gameScene.shopBtn.onClick.RemoveAllListeners();
        gameScene.shopBtn.onClick.AddListener(() => { ShopController.Setup().Show(); });
    }

    public void GroundAttach(EmptyDirt emptyDirt)
    {
        if (emptyDirt.dirtState == DirtState.EmptyDirt)
        {
            gameScene.txtAttachBtn.text = "Plant";
            gameScene.attachBtn.gameObject.SetActive(true);
            gameScene.attachBtn.onClick.RemoveAllListeners();
            gameScene.attachBtn.onClick.AddListener(() => {
                if (selectedPlant == null)
                    ShopController.Setup().Show();
                else
                    emptyDirt.PlantingPlant(selectedPlant);
            });
        }
        else
        {
            if (emptyDirt.IsCanClaim == true)
            {
                gameScene.txtAttachBtn.text = "Claim";
                gameScene.attachBtn.gameObject.SetActive(true);

                gameScene.attachBtn.onClick.RemoveAllListeners();
                gameScene.attachBtn.onClick.AddListener(() => {
                    emptyDirt.CanClaim();
                });
            }
            else
            {
                gameScene.txtAttachBtn.text = "";
                gameScene.attachBtn.gameObject.SetActive(false);
                gameScene.attachBtn.onClick.RemoveAllListeners();
            }
        }
    }

    public void TreeAttach(TreeElement treeElement)
    {
        if (treeElement.IsCanClaim == true)
        {
            gameScene.txtAttachBtn.text = "Claim";
            gameScene.attachBtn.gameObject.SetActive(true);

            gameScene.attachBtn.onClick.RemoveAllListeners();
            gameScene.attachBtn.onClick.AddListener(() => {
                treeElement.CanClaim();
            });
            Debug.LogError("dzo true");
        }
        else
        {
            gameScene.txtAttachBtn.text = "";
            gameScene.attachBtn.gameObject.SetActive(false);
            gameScene.attachBtn.onClick.RemoveAllListeners();
            Debug.LogError("dzo !true");
        }
    }

    public void ActionExit()
    {
        gameScene.attachBtn.onClick.RemoveAllListeners();
        gameScene.attachBtn.gameObject.SetActive(false);
    }
}
