using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour, IPopup, IPopupButtons
{
    Action buttonLeft;
    Action buttonRight;

    public static PopupManager Instance { get; set; }

    public GameObject background;
    [Header("Popup Information")]
    public GameObject popup;
    public Text title;
    public Text information;
    [Header("Buttons Text")]
    public Text txtLeft;
    public Text txtRight;
    [Header("Buttons")]
    public Button btnLeft;
    public Button btnRight;

    //########################################################
    //  enum
    //########################################################
    public enum Popup
    {
        TimeInformation,
        OneButton,
        TwoButtons
    }

    //########################################################
    //
    //########################################################
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    //########################################################
    //  interface implementation
    //  IPopup
    //########################################################
    public void ShowPopup(Popup popupType, IPopupSettings popupSettings, Action right = null, Action left = null)
    {
        buttonLeft = left;
        buttonRight = right;

        popup.SetActive(true);
        background.SetActive(true);

        switch(popupType)
        {
            case Popup.TimeInformation:
                TimeInformation(popupSettings);
                break;
            case Popup.OneButton:
                OneButton(popupSettings);
                break;
            case Popup.TwoButtons:
                TwoButtons(popupSettings);
                break;
        }
    }
    public void HidePopup()
    {
        buttonLeft = null;
        buttonRight = null;

        background.SetActive(false);

        if (popup.activeSelf)
            popup.SetActive(false);
    }
    public bool IsActive()
    {
        if (popup.activeSelf)
            return true;
        else
            return false;
    }

    //########################################################
    //  interface implementation
    //  IPopupButtons
    //
    //  !!! <<right button>> is also a button
    //  for <<popup with one button>>
    //########################################################
    public void ButtonLeftAction()
    {
        if (buttonLeft != null)
            buttonLeft();
        else
            HidePopup();
    }
    public void ButtonRightAction()
    {
        if (buttonRight != null)
            buttonRight();
        else
            HidePopup();
    }

    //########################################################
    // popup settings
    //########################################################
    private void TimeInformation(IPopupSettings popupSettings)
    {
        btnRight.gameObject.SetActive(false);
        btnLeft.gameObject.SetActive(false);

        title.text = popupSettings.Title;

        StartCoroutine(TimerInformationPopup(popupSettings));
    }
    private void OneButton(IPopupSettings popupSettings)
    {
        btnRight.gameObject.SetActive(true);
        btnLeft.gameObject.SetActive(false);

        title.text = popupSettings.Title;
        information.text = popupSettings.Information;
        txtRight.text = popupSettings.ButtonRight;
    }
    private void TwoButtons(IPopupSettings popupSettings)
    {
        btnRight.gameObject.SetActive(true);
        btnLeft.gameObject.SetActive(true);

        title.text = popupSettings.Title;
        information.text = popupSettings.Information;
        txtRight.text = popupSettings.ButtonRight;
        txtLeft.text = popupSettings.ButtonLeft;
    }
    IEnumerator TimerInformationPopup(IPopupSettings popupSettings)
    {
        for (int i = popupSettings.Timer - 1; 0 <= i; i--)
        {
            information.text = popupSettings.Information + " " + i;
            yield return new WaitForSeconds(1f);
        }

        HidePopup();
    }
}
