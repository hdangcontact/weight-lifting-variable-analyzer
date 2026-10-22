## Purpose:
	- Analyze how different training variables correlate with speed of strength progress for 
	  exercises tracked in Excel to build a more effective training program

## Scope:
	- Take workout data from an Excel spreadsheet and add entries to a database
	- Graph and compare the rate of strength progress for a given exercise
	  between different values for a training variable (weekly sets, reps in reserve, weekly frequency)

## Limitations:
	- The weight and reps tracked will be the first set of an exercise because you are able
	  to accurately guage strength when you're the least fatigued.
	- Weekly sets and frequency are planned values rather than calculated based on
	  days since your last entry for that exercise. It prevents the use of fractional values
	  that make it more difficult to group data and compare progress for 2x vs 3x frequency,
	  for example.
	- Strength is measured based on estimated 1 rep max calculated from weight and reps.
	  The accuracy of the 1 rep max value decreases as reps go above 10.
	- Training values are correlative with strength increase, not causal. If the user does
	  not isolate a single training variable and keep everything else the same,
	  they cannot say that a variable "caused" greater progress because another variable
	  may be a confounding factor. The most accurate way to use the program is to test
	  1 variable at a time for a prolonged period, change it, and then measure progress
	  for another prolonged period. After testing both, use the application to analyze
	  your progress when comparing the two variables.
	- Does not support bodyweight exercises unless you put your bodyweight as the weight

## MVP:
	- Upload an .xlsx file
	- Add the data from the .xlsx file to a database
	- Skip non-acceptable rows of data and report them as either
		- already imported
		- or outside the acceptable range of a variable
	- Graph the strength progress (calculated 1RM) over time for any given exercise
	- Compare the graph of one value of a training variable with a graph
	  of a different value for that variable
	  to show the difference in speed of strength increase over time
	- Support this feature for multiple training variables (weekly sets, rir, weekly frequency)
	- Calculate and display a linear regression line and correlational (R^2) value
	  for each graph.

## Data Model:


### Exercises table:

|	Column	|	Type	|	Constraints			|	Notes	|
|----------	|---------	|----------------		|---------	|
|id			|int		|primary key, no range	|			|
|name		|string		|unique, 1-45 char		|			|

"name" column is unique but not a primary key. This ensures the name of an exercise is changeable,
and can be changed from one row rather than requiring an UPDATE CASCADE.

### Entries table:

|	Column			|	Type	|	Constraints					|	Notes							|
|----------			|---------	|----------------				|---------							|
|id					|int		|primary key					|									|
|date				|DateOnly	|not null						|UNIQUE (date, exercise_id)			|
|exercise_id		|int		|FK (exercises.id), not null	|UNIQUE (date, exercise_id)			|
|weight				|decimal	|not null, 1-2000				|									|
|reps				|int		|not null, 1-100				|									|
|weekly_sets		|int		|not null, 1-100				|									|
|rir				|int		|not null, 0-10					|									|
|weekly_frequency	|int		|not null, 1-7					|									|
