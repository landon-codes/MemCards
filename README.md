# MemCards

## Description
MemCards is a multi-platform flash card app that prioritizes rich funtionality without a price tag. MemCards is a free and open source software that can be installed on Windows, Mac, Android, and IOS. This app is build using .NET MAUI and .NET 9.0 to provide this high level of cross platform support.

## How it Works
This app uses file packages (the extention is not yet confirmed) to share and save flash card sets. These files are based of XML, and contain the title, author, and list of cards in a set.
Here is an example file for a set called "Example Set" authored by "Someone":
```xml
<?xml version="1.0" encoding="UTF-8"?>
<CardPackage>
  <Title>Example Set</Title>
  <Author>Someone</Author>
  <Cards>
    <Card Term="Job" Definition="Uhhhhhhh" />
    <Card Term="North Africa" Definition="A continent" />
  </Cards>
</CardPackage>
```
Using this method provides safety and privacy for individual users, since I don't have training for safely making an account/database system for the app. It also allows users to freely control who sees the content they make on this app, and how that content is shared or stored.

## Installation
Currently this application is still in development with no stable builds.
If you are looking to contribute to this project you can view the contribution intructions below.

Planned installation methods:
1. **Manual installation**
Involves manually downloading the project files from a .zip folder and compiling them yourself with the .NET SDK. 
Reccomended for individuals with programming experience who want customization of their tools.
2. **Binary installation**
Involves downloading pre-compiled binaries and moving them to the desired location in your device to run.
Reccomended for users who want the regular application but customization for where they can store the app. With the correct setup, this should be able to make a portable version of the app as well for running on flash drives.
3. **Native installation**
I plan on looking into getting installation wizards for the desktop apps and uploading the mobile apps to their respective stores. This may not happen though.

## Contributing
Contributions are welcome and appreciated. The [GitHub](https://github.com/landon-codes/MemCards) page for this project often has issues posted for things that need done or for things external contributors can help with.
The issues page is [here](https://github.com/landon-codes/MemCards/issues).

### Technologies
1. .NET SDK (version 9.0 or greater)
2. .NET MAUI

## License
This project is under the Apache 2.0 license.