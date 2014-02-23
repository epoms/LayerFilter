LayerFilter
===========

Window for Unity that allows you to see which objects are on which layer by assigning colors to each layer.

To use this tool, just put the LayerFilter.cs file in the Editor folder inside your project's assets. Create an Editor folder if you don't have one.

LayerFilter will then be added in the Window dropdown menu.

Choose a color for each layer and then hit apply to change every object to the color of their corresponding layer. 

Clear turns the colors back to white.

WARNING
this modifies the color of spriterenders so it could cause problems with game functions that deal with initial colors.
Also it only works on sprites, not 3D materials.
