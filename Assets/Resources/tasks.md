# Step 0: Project

Create a new project, with the package _2D Tilemap Extras_ included

## Layers

Pacman
Ghost
Pellet
Obstacle
Node

## Step 1: Sprites

- Sprites should be 16 x 16: split the original sprites32.png into multiple sprites
- Why 16? <https://gamedev.stackexchange.com/questions/100546/why-are-16%C3%9716-pixel-tiles-so-common>

## Step 2: Maze

- Black background set in Camera objects
- Maze is made of 8 x 8 tiles, for a total number of 28 x 31 (224 x 248 pixels);
- Tiles are drawn with GIMP
- Rule Tile?

## Step 3: Basic movement

- Basic movement up/down, left/right

## Step 4: Collision

- Foreground with Tilemap for collision (Tilesmap Collider 2D). Pacman stops if it collides with walls.
- Walls do not have friction: add a material through Create/2D/Physics Material 2D and add to Composite Collider 2D of the Maze

## Step 5: Crossroads

- The verse of the direction can always change (both orizzontally and vertically)
- Crossroads to check if entities can change direction.
- Create a working croassroad

## Step 6: Pellets

- Create a small pellet (with tag) prefab
- Create a big pellet (with tag) prefab
- Create/2D/Tiles/Rule tile for an object palette or select GameObject brush from the menu
see also <https://medium.com/nerd-for-tech/how-to-use-gameobject-brush-7be9a1ddeae9>
There are 240 pellets and 4 power pellets

Create a 2dCircle for nodes

## Step 7: AI how do ghosts chase Pacman?

- <https://docs.unity3d.com/Manual/Navigation.html>
- A* algorithm project: <https://arongranberg.com/astar/>
- 2D PATHFINDING - Enemy AI in Unity <https://www.youtube.com/watch?v=jvtFUfJ6CP8>

## States and events

Pacman

- Normal
- Empowered
- Dead

Ghosts

- Chase Pacman
- Scatter (each ghost has a fixed target tile, each of which is located just outside a different corner of the maze)
- Frightened (pseudorandomly decide which turns to make at every intersection, also turns dark blue, moves much more slowly and can be eaten by Pac-Man)

When power pellet is eaten
    - Pacman state changes
    - Ghosts state changes
    - Sound is emitted
    - Music changes
    - A timer starts
