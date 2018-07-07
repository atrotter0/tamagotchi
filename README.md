# Tamagotchi Simulator

#### Epicodus C# exercise, 07.05.18

#### By Abel Trotter & David Ngo

## Description

A remake of the classic Tamagotchi toy. Add a tamagotchi and try and keep it alive!

#### How To Play
* Add a tamagotchi to start the life cycle timer.
* Every 10 seconds, the life cycle timer will remove a random value from your pet's stats.
* Click the Feed, Play, or Rest buttons to refill different portions of your pet's stat pools.
* Gain exp and level up by keeping stat pools above 0 during each life cycle tick.
* Leveling up will add a random amount to your stat pools.
* If any stat falls below 0, or a life cycle tick drops a stat below 0, your pet will die.
* If your pet dies, bury it and try again! See if you can beat your previous record!
* For an extra challenge, try adding multiple pets!

#### Additional Notes
**Feed:** Adds a medium replenish to the **Hunger** pool, adds a minor replenish to the **Happiness** and **Energy** pools.

**Play:** Adds a major replenish to the **Happiness** pool, adds a minor decay to the **Hunger** and **Energy** pools.

**Rest:** Adds a medium replenish to the **Happiness** and **Energy** pools, adds a minor decay to the **Hunger** pool.

## Specs

| Behavior | Input | Output |
|----------|-------|--------|
| Behavior | input | output |

## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Clone the repo
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to start the server

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* JavaScript
* jQuery 3.3.1
* jQuery UI
* AJAX
* Bootstrap 3.3.7

## Links

* [Github Repo] (https://github.com/atrotter0/tamagotchi)
* [Heroku App] (https://tamagotchi-dotnet.herokuapp.com/)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Abel Trotter & David Ngo**
