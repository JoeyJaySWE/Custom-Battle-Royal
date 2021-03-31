# Custom-Battle-Royal

Handing for my course in C# during my first year at YRGO.

## What is this?

Anyone remember the old style GBA Pokemon games?
Well, here you can do far more than a pokemon battle, my friend.
Here you can create your own fighter through a text based interface in your terminal.


## How does it work?
You navigate using the error keys an use the enter key to make your selection.
You can choose between single computer Player VS Player or Player VS AI.
Once you selected your your mode, you get to choose to either create your own fighter,
or pick a premade one.

## Premade chracter
Upon picking a premade one, you'll see a short summery of what they can do.
You get 4 attacks with each fighter that can you can decide yourself on creation.
If you don't like the chracter, you can always preview another or create a new one.

### Creating new Fighter
First thing you'll need is a good name for you fighter. So satrt off by typing one down.
Once that is done, you get 4 different actions to add.
Start by typing the name you want to give your first action and press enter.
(Repeat this for the following 3 actions).

Once the names are set, the game will pick each action in order and give you
a list of 6 different options of effects to apply to it:
* Tackle (deal normal 10HP damage to opponent)
* Heal (Heal yourself for upto 30HP OBS! Limited to 4 uses / game)
* Stun (Give your opponent a 33% chance to be unable to attack for 4 rounds. (new check each round).
* Dodge (Get a 33% chance to take 0 damge from next attack)
* Guard (Bracing yourself, you'll only take half the amount of damge of next incoming attack)
* Rage (You sacrifce 2 attack rounds, in exchange you'll deal 30HP damge on your third + any damage tacken)

Once you've made your descsion your always free to change it before finalizing. You fighter will then be saved.

### AI
AI apponent has the same rules of actions like you do. Only difference is that he will pick an action at random.
You may chose yourself if you'd like to have a random AI chosen or chose which fighter it will use.

### Game
Game starts off by asking how long you want your fights, and provide you with 4 options:
* Short (Each fighter have 50HP)
* Medium (Each fighter has 100HP)
* Long (Each fighter has 200HP)
* Custom (Set the fighter HP yourself)

After this you'll be provided with a short intro text then you'll find the players name (listed in cyan)
at the top with it's health, folllowed by the AI/Player2 (listed in Red).
Each player have his/hers attacks printed out together with 2 additional options.
* Do nothing (If you want to give your oponent a freebie)
* Surrender (Quit the game and make your opponent the victor)

After you selected an attack, there will be a miss chance involved.
If you hit, the effect is applied, if not *sad trumpet noice*.
Even if you where to apply heal for yourself, there is a risk the opponent may interveen.

### Game Over
Once the match is done, the game's over and the winner is appointed.
You'll also have the option of a rematch with the same fighters or quit the game.

### Future improvments
There is a ton of options I'd like to include to the game for future updates.
Among them being the following:
* Elemental damge and weaknes strengths system.
* Online play
* Custom number of combatants
* AI difficulty settings
* Win / Lose stats for each fighter type.
* Registration with level systems based on exp system.
