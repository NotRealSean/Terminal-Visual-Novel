#!/bin/bash
echo "!Welcome to update script!"
if [ -f "./gameVersion" ]; then
  VERSION=$(cat ./gameVersion)
else
  VERSION='not found!'
fi
STABLE_VERSION=$(wget https://raw.githubusercontent.com/NotRealSean/Console-Visual-Novel-Text-Base-Game/main/version -q -O -)

echo ""
if [ "$VERSION" = "$STABLE_VERSION" ]; then
  echo "Game version is a match!"
else
  if [ "$VERSION" = "not found!" ]; then
    echo "Please open the game first before you run this script!"
  fi
    echo "Game version does not match!"
fi

echo ""
echo "Your game version: $VERSION"
echo "Stable release version: $STABLE_VERSION"
echo -n "Would you like to update the game?(y/N)"
read UPDATE_COMFIRM
if [ "$UPDATE_COMFIRM" = "y" ]; then
  echo "Select version you want to update"
  echo "1) Git"
  echo "2) Stable"
  echo -n " >" && read UPDATE_VERSION
  if [ "$UPDATE_VERSION" = "1" ]; then
    echo "Downloading Git version..."
    if [ -f "./.cache" ]; then
      cd .cache
      git clone https://github.com/NotRealSean/Terminal-Visual-Novel
      cd Terminal-Visual-Novel
      cp Program.cs ../ ../Program.cs
    else 
      mkdir .cache
      cd .cache
      git clone https://github.com/NotRealSean/Terminal-Visual-Novel 
      cd Terminal-Visual-Novel
      cp Program.cs ../ ../Program.cs
    fi
  elif [ "$UPDATE_VERSION" = "2" ]; then
    echo "You select $UPDATE_VERSION"
  else
    echo "You didn't select"
  fi
else
  echo "You denied"  
fi
