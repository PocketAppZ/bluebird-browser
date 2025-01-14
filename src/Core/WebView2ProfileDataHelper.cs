﻿namespace Bluebird.Core;

public static class WebView2ProfileDataHelper
{
    public static async Task ClearAllProfileDataAsync()
    {
        if (MainPageContent.MainWebView.CoreWebView2 != null) {
            CoreWebView2Profile profile = MainPageContent.MainWebView.CoreWebView2.Profile;
            await profile.ClearBrowsingDataAsync();
        }
        else
        {
            NotificationHelper.NotifyUser("Error", "An error occurred while trying to clear user profile data");
        }
        await FileHelper.DeleteLocalFile("Favorites.json");
        SettingsViewModel.SettingsVM.FavoritesList.Clear();
    }
}
