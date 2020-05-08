### Goal:
Write proper object-oriented code, where objects will completely replace procedural code in order to achieve flexibility and maintainability.

### Design Patterns and Practices used in these samples:
- State Pattern
- Composite Pattern
- Strategy Pattern
- Template Method Pattern
- Immutable classes
- Value objects
- Null Object Pattern
- Special Case Pattern
- Option Pattern
- Pattern Matching
- Double Dispatch Pattern
- Factory Pattern
- Rules Pattern
- State Machine pattern

### Use cases for this demo:

- Replace branching over booleans:
	- use the state pattern.
	
- Turning algorithms into strategy objects:
	- identify the moving parts of an algorithm
	- use template method and the strategy pattern.

- Fix aliasing bugs:
	- use value objects
	- use immutable classes.

- Remove null checks:
	- use the null object pattern.
	
- Remove optional calls:
	- turn optional call into calls on optional object-oriented
	- represent optional object as a collection
	- wrapt a collection into an option type
	- improvement: add pattern maching to options.
	
- Replace Switch statements:
	- move the switch statement and the enum into a separate class by encapsulating representation (DeviceStatus)
	- make the class an value oject in order to use the objects of this class as key for a dictionary
	- turn multiway branching into a dictionary object-oriented
	- substitute the multiway branching at runtime by using a factory to create the dictionary.

- Replace chained branches into the Chain of Rule Object: 
	- use the rules pattern
	- convert rules to objects and organize them into a chain
	- the rule is the if-then-else instruction, but turned into an object
	- chaining decides rules order, highest priority rule comes first
	- substitute the chained branches branching at runtime by using a factory to create the rules.
