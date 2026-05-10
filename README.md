# MemCards

## Description
MemCards is a multi-platform flashcard app that prioritizes rich functionality without a price tag. MemCards is a free and open source software that can be installed on Windows, Mac, Android, IOS, and Linux. This app is built using Avalonia and .NET 10.0 to provide this high level of cross platform support.

This app is in the early stages of development, with no usable builds. You are welcome to look at the [issues](https://github.com/landon-codes/memcards/issues) page if you are interested in contributing.

## How it Works
This app uses file packages to share and save flashcard sets. These files are based on Json, and contain the title, author, and list of cards in a set.
Here is an example file:
```json
{
  "title": "Animal Terms",
  "description": null,
  "authors": "someone",
  "cards":
  [
    [
      "Feline",
      "A term for cats",
      "cat.png"
    ]
    [
      "Bovine",
      "A term for cattle",
      null
    ]
  ]
}
```
Using this method provides safety and privacy for individual users. It also allows users to freely control who sees the content they make on this app, and how that content is shared or stored.

### Package Manager

MemCards uses a simple API package manager. Its code can be found in the `PackageManager` directory.

The package manager has two classes:

1. Card
2. CardSet

**Card**

The Card class represents a card in a set. It contains a term, definition, and potential path to an image.

The code is very simple, as it is only built to contain data, and has no functions.

**CardSet**

The card set represents a whole flashcard set, and is more complicated.

The CardSet class contains a title, potential description, potential author(s), and a list of cards.

There is only one function, which is the `WriteJson` function. It is used to convert the CardSet class into a Json file that can be saved and moved. The most common use for this function will be when creating set packages. 

It has three constructors: an empty constructor, an import constructor, and a full constructor.

The empty constructor sets the base values as follows:
- `title` : `"None"`
- `description` : `null`
- `authors` : `null`
- `cards` : `new List<Cards>();`

The import constructor takes the path (as a string) to a json file for a package. It reads the file and uses the information inside to generate an instance of the CardSet class.

The full constructor takes arguments for all the needed data and generates an instance of the CardSet class.

## Installation
Currently this application is still in development with no stable builds.
If you are looking to contribute to this project you can view the contribution instructions below.

**1. Manual installation**

Involves manually downloading the project files from a .zip folder and compiling them yourself with the [.NET SDK](https://dotnet.microsoft.com/en-us/download). 
Recommended for individuals with programming experience who want customization of their tools.

**2. Binary installation**

Involves downloading pre-compiled binaries and moving them to the desired location in your device to run.
Recommended for users who want the regular application but customization for where they can store the app. With the correct setup, this should be able to make a portable version of the app for flash drives.

## Contributing
Contributions are welcome and appreciated! The [GitHub page](https://github.com/landon-codes/MemCards) for this project often has issues posted for things that need done or for [issues](https://github.com/landon-codes/MemCards/issues) external contributors can help with.

### Technologies
1. .NET SDK (version 10.0 or greater)
2. Avalonia
3. [JsonStorage](https://github.com/landon-codes/JsonStorage)

## License
This project is under the Apache 2.0 license.