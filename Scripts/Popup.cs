using UnityEngine;
using System.Collections;
using System;

public class Popup : IPopupSettings
{
    public string title;
    public string information;
    public string buttonRight;
    public string buttonLeft;
    public int timer = 0;

    public Popup(string information, string buttonRight = null, string buttonLeft = null, string title = null, int timer = 0)
    {
        this.information = information;
        this.buttonRight = buttonRight;
        this.buttonLeft = buttonLeft;
        this.title = title;
        this.timer = timer;
    }

    //########################################################
    //  interface implementation
    //  IPopupSettings
    //########################################################
    public string Title
    {
        get
        {
            if(title != null)
                return title;
            else
                return string.Empty;
        }
    }
    public string Information
    {
        get
        {
            if(information != null)
                return information;
            else
                return string.Empty;
        }
    }
    public string ButtonRight
    {
        get
        {
            if(buttonRight != null)
                return buttonRight;
            else
                return string.Empty;
        }
    }
    public string ButtonLeft
    {
        get
        {
            if (buttonLeft != null)
                return buttonLeft;
            else
                return string.Empty;
        }
    }
    public int Timer
    {
        get
        {
            return timer;
        }
    }
}
