# A course on SOLID design principles and frequently used software design patterns

Here's the source-code for a course on [SOLID design principles](https://en.wikipedia.org/wiki/SOLID) and much used [software design patterns](https://en.wikipedia.org/wiki/Software_design_pattern) that I once taught.

Although I'm no longer at hand to teach it, the [course presentation](https://docs.google.com/presentation/d/1R8Lo5vN4hIiOiiKiB7E1UmvbtA64YwyLrazw738YlPE/edit?usp=sharing) should make it relatively easy to dive into it, for self-teaching purposes. 

The - sufficiently annotated - source-code is in C#. But really the subject is language-agnostic, and might be easily converted into a different, similar object-oriented language.

As always I encourage issues and requests, so let me know if there's anything I can do to help.

___

## Course content

_(One-liners supplied for mnemonic purposes - they do **not** do justice to the complexities of the topics.)_

### SOLID design principles:

- [x] Single Responsibility principle

  "Split up your component if it has more than one reason to change"

- [x] Open/Closed principle

  "Let your component be open to extension, but closed for modification"

- [x] Liskov Substitution principle

  "Honor the contract"

- [x] Interface Segregation principle

  "Split up your interfaces if any of its methods won't be implemented"

- [x] Dependency Inversion principle

  "Give your component all the stuff it needs to do its job"


### Frequently used design patterns:

- [x] Strategy pattern

  "Allow for interchangeable algorithm implementations"

- [x] Factory pattern

  "Out-source the creation of your components"

- [x] Decorator pattern

  "Add functionality to existing components"

- [x] Facade pattern

  "Offer a unified front to a complex system"

- [x] Template Method pattern

  "Execute a series of common steps, though still allowing for diversification"

- [x] Adapter pattern

  "Build a bridge, an 'adapter', between components"

- [ ] Composite pattern

  "Enable node-leaf-like structures"
