The classes and objects participating in this pattern are:

Prototype  (ColorPrototype)
	declares an interface for cloning itself

ConcretePrototype  (Color)
	implements an operation for cloning itself

Client  (ColorManager)
	creates a new object by asking a prototype to clone itself

--------------------------------------------------------------------------------------------------------------------------------------------
When we need to build a data structer for some object. And we dont need to create new object all this time.
Ex
Color red = new Color(...)
Color purered = new Color(...)
Color darkred = new Color(...)

We just create a prototype of this kind of object and use dictionaty to store data and and clone it.