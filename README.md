Impossible Game 3D !

Just a fun weekend project to try to make the Imossible Game in 3D, but not only that an endless runner game.  
  
Duration: 2 Days, so far  
Tech: Unity, C#  
  
![GameScene](https://github.com/nice1stu/ImpossibleGame3D/assets/112468923/3325d0c7-f4ea-426f-afa3-cbef5976fcb0)

Just for fun and to refresh my Unity / C# skills, decided to reimagine the Impossible Game, but in 3D, but also instead of designing an entire level, made it randomly generate the floor and hazards that the player encounters. One of the main objectives of this little side project was also to teach myself a little about Object Pooling, a very efficient method of instantiating many reuseable objects in a scene. By instantiating a pool of objects to be used in game at game start, and instead of instantiating and destroying the objects, they are simply activated from the pool when need, deactivated and returned to the pool when no longer required ready to be used again.  

![CreateObjectPool](https://github.com/nice1stu/ImpossibleGame3D/assets/112468923/b4f8f97c-edc6-4ce5-afa0-ecf66ac3f698)

A ground tile spawner continuously spawns the ground tiles from the object pool. There are 4 types of tiles, the normal walkable ground tiles, the Block and Spike Obstacle tiles and a "Gap" tile. These are spawned by random chance in the spawner script. At the same time the spawner itself moves up and down randomly to change the level of the tiles being spawned. Tile are spawned at random batch at a time.  

![RandomGeneration](https://github.com/nice1stu/ImpossibleGame3D/assets/112468923/2869f532-cd98-4e49-a40e-7691ecc7daf4)

Check out the Game Trailer  
[![click to watch the video](https://img.youtube.com/vi/lCNW2TioChc/maxresdefault.jpg)](https://youtu.be/lCNW2TioChc)  
