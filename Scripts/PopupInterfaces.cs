public interface IPopup
{
    void ShowPopup(PopupManager.Popup popupType, IPopupSettings popupSettings, System.Action right = null, System.Action left = null);
    void HidePopup();
    bool IsActive();
}

public interface IPopupButtons
{
    void ButtonLeftAction();
    void ButtonRightAction();
}

public interface IPopupSettings
{
    string Title { get; }
    string Information { get;}
    string ButtonRight { get; }
    string ButtonLeft { get; }
    int Timer { get; }
}