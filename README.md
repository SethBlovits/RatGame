# RatGame

All of the scripts I used are in the Scripts folder in Assets.

I'll highlight some of the scripts with the code I believe will be some of the things you are grading:

Spawning/Despawning: lobbyTransitionSpawner.cs
Host Controlled Start: LobbyManager.cs
Game Lobbies: LobbyManager.cs
RPC Calls:LobbyTransitionSpawner.cs, CheesePickup.cs
SyncPlayer Animation: playerDetection.cs -- The character asset is the only thing with animations. But they are synced with host and client
Collision: playerDetection.cs,ventInteraction.cs,trashcanscript.cs,CheesePickup.cs,mousetrapBehaviour.cs
Pickup Interactions: CheesePickup.cs
Scene Switching: cheeseCheck.cs,LobbyManager.cs,buttonScript.cs
Chat Dialogue: chatUI.cs (The chat works by pressing "t" to open the box. Pressing "Enter" will send the message and make the chat box go invisible)

Unfortunately, I don't have any shared attributes like a health system

The game is won by moving all the cheese from the main room to the starting room if you would like to test the game.
