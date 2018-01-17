using UnityEngine;
using System.Collections;

public class ExampleSingelton : MonoBehaviour
{
    IPopup popup;
    IPopupSettings popupSettings;

    int level = 1;

    //########################################################
    // examples of using popups
    //########################################################
    public void LevelUp()
    {
        SetInterfaces();

        level++;

        popupSettings = new Popup("You have reached level "+level.ToString(), "OK", null, "Congratulations!");
        popup.ShowPopup(PopupManager.Popup.OneButton, popupSettings, null, null);
        Debug.Log(popupSettings.Information + " "+popupSettings.ButtonLeft.ToString());
    }
    public void Buy()
    {
        SetInterfaces();

        popupSettings = new Popup("Do you want to buy 15 swords?","Buy", "Cancel", "Shop");
        popup.ShowPopup(PopupManager.Popup.TwoButtons, popupSettings, BuyItem, null);
    }
    public void TimeClose()
    {
        SetInterfaces();

        popupSettings = new Popup("Popup will close in...", null, null, null, 4);
        popup.ShowPopup(PopupManager.Popup.TimeInformation, popupSettings);
    }
    public void ExitGame()
    {
        SetInterfaces();

        popupSettings = new Popup("Do you want to leave the game?", "Exit", "Cancel", "Exit Game");
        popup.ShowPopup(PopupManager.Popup.TwoButtons, popupSettings, () => { Debug.Log("[ExampleSingelton] : exit game"); Application.Quit();});
    }

    //########################################################
    // set interfaces
    //########################################################
    private void SetInterfaces()
    {
        if(popup == null)
            popup = PopupManager.Instance;
    }

    //########################################################
    // popup delegates
    //########################################################
    private void BuyItem()
    {
        popupSettings = new Popup("You bought 15 swords.", "OK");
        popup.ShowPopup(PopupManager.Popup.OneButton, popupSettings, null, null);
    }
}
