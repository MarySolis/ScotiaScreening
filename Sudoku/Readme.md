### Project Description

A C# implementation of a Sudoku game solution verifier, it is divided in 3 projects:

* A console app. that serves as an entry point, accepts a file with a game solution, parses and returns true/false if it is a valid solution or not
* An assembly that contains the models, file parsing code and the solution verifier class
* Unit tests

###	Remarks

* Although our solution supports arbitrary board/block sizes, input files don't describe game dimensions so the entry point and unit tests are hardcoding 9x9 games with 3x3 blocks
* Boards are stored in a single array (vs a bidimensional arrays which might be more intuitive) to simplify the code base since we can then just iterate using offsets and arithmetic operations

### Pending items

- [x] Design architecture and projects structure
- [x] Write unit tests
- [x] Code solution verification logic with an in memory solution array
- [x] Implement file parsing and error handling
- [ ] Add log4net
- [ ] Add a DI framework