# 2d-console-game-engine
Implementation of a simple 2D game engine for the windows console written in C#

##Motivation:
I've decided to code this simple game engine in the high level C# because the main purpose of this is educational & for fun.
I wanted to create a good OO design of the engine that will have a nice portion of abstraction and it'll be as versatile as possible.
Because of this I went for such an easy to use high level language like C# and haven't used languages like C++. On the other hand, it wouldn't be so hard to translate the whole code base into C++.

The main resource I'm using while developing this is the book *Game Coding Complete, Fourth Edition*.

#Usage:
Dependencies:
- Json.NET (Newtonsoft.Json NuGet package) -> This package is used for parsing JSONs
- System.Windows.Forms -> This is used mostly for message pump

The project is developed with Visual Studio 2017 but I think the older versions should be compatabile, too.

Just Open the project with your version of VS and all the dependencies should be loaded automatically.

#TODO
- Implement simple physics system for collisions detection
- Implement hook for the windows message pump to process input -> upgrading the InputManger
- Shut down phase of the game engine
- Deeper description of the project