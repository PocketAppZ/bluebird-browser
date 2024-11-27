﻿namespace Bluebird.Pages;

public sealed partial class WebViewErrorPage : Page
{
    public WebViewErrorPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        string ErrorMsg = string.Empty;
        if (e.Parameter != null)
        {
            var parameters = (WebView2CreationError)e.Parameter;
            ErrorMsg = parameters.ErrorMsg;
        }

        muxc.InfoBar infoBar = new()
        {
            IsOpen = true,
            Severity = muxc.InfoBarSeverity.Error,
            Title = "An error occured",
            Message = "Read the details below",
            IsClosable = false
        };
        ErrorList.Children.Add(infoBar);

        if (!string.IsNullOrEmpty(ErrorMsg))
        {
            TextBlock ErrorMsgDisplay = new()
            {
                Text = ErrorMsg,
                IsTextSelectionEnabled = true
            };
            ErrorList.Children.Add(ErrorMsgDisplay);
        }
    }
}