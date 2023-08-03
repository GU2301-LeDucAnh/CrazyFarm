using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DG.DemiLib.External.DeHierarchyComponent;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    public MenuUIScene menuScene;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Init();
    }

    void Init()
    {
        menuScene.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
