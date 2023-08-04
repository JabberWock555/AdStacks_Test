using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        pickUp.onClick.AddListener(setPickUp);
        Drop.onClick.AddListener(setDropDown);
    }

    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject Level;
    [SerializeField] private GameObject HUD;
    [SerializeField] private Button pickUp;
    [SerializeField] private Button Drop;

    bool pick = false;
    bool drop = false;

    private void Start()
    {
        startScreen.SetActive(true);
        Level.SetActive(false);
        HUD.SetActive(false);
    }
    public void Play()
    {
        startScreen.SetActive(false);
        Level.SetActive(true);
        HUD.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Exit()
    {
        startScreen.SetActive(true);
        Level.SetActive(false);
        HUD.SetActive(false);
    }

    private void setPickUp()
    {
        if (pick == false) pick = true;
        else pick = false;

    }

    private void setDropDown()
    {
        if (drop == false) drop = true;
        else drop = false;

    }

    public bool PickUp()
    {
        return pick;
    }

    public bool DropDown()
    {
        return drop;
    }
}
