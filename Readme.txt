This project is a part of the hiring assessment at MyHashhStash, by Shubh Singh
Build is for Windows
Version used of Unity: 2020.3.30f1
About Game:

- - - - - - - 

This project is meant to be a clone of the game 'paratroopers' made in 1982. The core functionalities such as
1) Helicopter movement and paratrooper spawn
2) Points system
3) Jets
4) Turret Movement
5) Death Conditions
have been achieved to the best of my abilities. Apart from these abilities, a bonus abilites has been added:
Ultimate Ability: it kills every soldier that has landed on the grounds, though you won't be awarded points for it
as it felt a bit overboard. Also, you gain one ultimate ability once you've killed 5 enemies consecutively: shooting
parachutes doesn't count.

- - - - - - - - - - 

About Code Structure:

The code has been kept fairly simple and easy to understand. The singleton pattern as well as the observer pattern has been 
used, though not extensively as there was no need. There was a conflict on whether to add object pooling or not, but 
ultimately decided against it as adding it didn't really affect performance(probably due to the low number of 
objects present at a given time). The old input system has been used, though the new one would've worked
just fine(maybe even better)

- - - - - - - - 

About Optimization

As observed from the profiler, the game has excellent performance(consistent >150FPS). The rare-spikes are caused by the rendering:
for instance, when many VFXs occur at the same time. Since most of the heavy work is being done by the GPU, and the CPU and RAM weren't
involved much with or without Object Pooling, I decided against using it.