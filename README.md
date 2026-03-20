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

## Contributing
Contributions are welcome and appreciated. The [GitHub](https://github.com/landon-codes/MemCards) page for this project often has issues posted for things that need done or for things external contributors can help with.
The issues page is [here](https://github.com/landon-codes/MemCards/issues).