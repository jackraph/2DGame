This new system is very modular and might be a little confusing at first.
The character controller acts as a composite object with the core logic all split off into appropriate classes.

The controller itself is not player specific and performs actions automatically based on input it reads from
an input provider class.

By using polymorphism we can create input providers that 'generate' input in various ways.
For example the player input provider simply reads input from unities input system and provides it that way. An
enemy input provider will generate its own input based on programmed AI. This could easily be expanded on for friendly npcs
etc.

Overkill for this project but I was doing similar in a personal project and figured I may apply it here aswell.