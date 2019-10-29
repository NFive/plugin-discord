# NFive Discord Plugin
[![License](https://img.shields.io/github/license/NFive/plugin-discord.svg)](LICENSE)
[![Build Status](https://img.shields.io/appveyor/ci/NFive/plugin-discord/master.svg)](https://ci.appveyor.com/project/NFive/plugin-discord)
[![Release Version](https://img.shields.io/github/release/NFive/plugin-discord/all.svg)](https://github.com/NFive/plugin-discord/releases)

Plugin to set client's Discord rich presence when playing on the server

## Before and After
![Before Screenshot](https://user-images.githubusercontent.com/43646/51639690-7828c900-1f59-11e9-9971-481d77c2aa26.png)
![After Screenshot](https://user-images.githubusercontent.com/43646/51639693-7828c900-1f59-11e9-85ea-f3e575535897.png)

## Installation
Install the plugin into your server from the [NFive Hub](https://hub.nfive.io/NFive/plugin-discord): `nfpm install NFive/plugin-discord`

## Configuration
```yml
# Your Discord application "Client ID" from https://discordapp.com/developers/applications/
app_id: 520598603568250881

# Text to show under the server name
description: My server description

images:
  # Large image details
  large:
    # "Rich Presence Asset" name from your Discord application
    asset: logo

    # Text to show on hover
    text: My Server

  # Small image details
  small:
    asset: nfive
    text: Server powered by NFive
```
