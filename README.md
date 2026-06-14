# Better Posters

**Better Posters** is a Jellyfin image fetcher for Movies and Shows that pulls configurable primary posters from [btttr.cc](https://btttr.cc). It uses the media item's IMDb ID and lets you choose poster badges, labels, rating source, language, and optional scheduled replacement from the Jellyfin plugin settings page.

**Minimum Jellyfin version:** 10.11.10

## Features

- **Movies and Shows:** Registers as a remote primary image provider for movie and series items.
- **Configurable Poster Overlays:** Toggle trend tags, quality badges, genre, rating, and age rating.
- **Rating Source Selection:** Use btttr.cc average ratings or choose IMDb, TMDB, Rotten Tomatoes, Metacritic, Trakt, Letterboxd, or Roger Ebert.
- **Multi-Language Posters:** Select English, Spanish, French, German, Portuguese, Italian, Dutch, Polish, Russian, Turkish, Arabic, Japanese, Korean, Chinese, Hindi, Swedish, or Czech.
- **Scheduled Replacement:** Optionally replace existing movie and show posters daily, weekly, or monthly.

## Installation Guide

### Step 1: Build the Plugin

1. Install the .NET SDK that can build `net9.0` projects.
2. From this repository, run:

    ```shell
    dotnet publish BetterPosters/BetterPosters.csproj -c Release
    ```

3. Locate the published `BetterPosters.dll`.

### Step 2: Install the Plugin

1. Stop Jellyfin.
2. Create a Better Posters plugin folder under your Jellyfin plugins directory.
3. Copy `BetterPosters.dll` into that folder.
4. Start Jellyfin.
5. Confirm **Better Posters** appears under **Dashboard -> Plugins -> My Plugins**.

This plugin is built for Jellyfin 10.11.10 and may not load on older Jellyfin versions.

## Configuration & Setup

Open **Dashboard -> Plugins -> My Plugins -> Better Posters**.

Default settings:

- **Trend Tags:** Enabled
- **Quality Tags:** Disabled
- **Genre:** Enabled
- **Rating:** Enabled
- **Source:** Average
- **Age Rating:** Disabled
- **Language:** English
- **Auto Update Posters:** Disabled

Auto update schedules:

- **Disabled:** Never replaces posters automatically.
- **Daily:** Runs at the start of each day.
- **Weekly:** Runs on Sunday at the start of the day.
- **Monthly:** Runs on the first day of the month.

Auto update replaces existing primary posters for Movies and Shows that have an IMDb ID.

## How to Apply Posters to Your Library

### Option A: Apply to a Single Movie or Show

1. Open a Movie or Show in Jellyfin.
2. Select **Edit Images**.
3. Search remote images.
4. Choose the Better Posters primary image.

### Option B: Apply During Metadata Refresh

1. Go to **Dashboard -> Libraries**.
2. Open the menu for a Movies or Shows library.
3. Select **Scan Library**.
4. Choose metadata refresh options that replace existing images.

### Option C: Apply Automatically

1. Open the Better Posters plugin settings.
2. Set **Auto Update Posters** to Daily, Weekly, or Monthly.
3. Save the configuration.
4. The scheduled task will replace matching movie and show primary images using the current poster settings.

## Troubleshooting

- **No Better Posters image appears:** Confirm the item has an IMDb ID. This plugin intentionally uses IMDb IDs for btttr.cc URLs.
- **Plugin does not load:** Confirm the server is Jellyfin 10.11.10 or newer in the 10.11 line and restart Jellyfin after copying the plugin DLL.
- **Poster did not change after selecting one:** Clear the browser cache or check another Jellyfin client. Jellyfin and browsers can cache images aggressively.
- **Scheduled update did not run monthly:** The task wakes daily at midnight and only performs monthly work on day 1 of the month.

## Disclaimer

This is an unofficial Jellyfin plugin. Poster artwork and generated image output are provided by [btttr.cc](https://btttr.cc).
