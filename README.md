# How to use

This is designed to have multiple people contributing their own solutions.

The idea is, that in every project, there are "generic" things for **everybody** to use followed by folders named after the current user, containing stuff specific to their puzzles.

## Setting up a new user

> For these examples we'll assume a new user named John - replace this with your name in the examples

1. Create a new folder named `App/Days/John` and add your first puzzle input to this folder. Each file should be named numerically after the corresponding day. Name the first one 1.txt.

2. Add a new User to `Domain.Constants.Users`, following the existing structure.o

3. Create a new folder with your name (John in this example) inside Helpers, inside Domain and inside Services.

4. Create a new empty service inside `Services/John` named `JohnDayService`. Add the following boilerplate code and remember to change John to your name:

```cs
using Domain.Constants;

namespace Services.John;

public abstract class JohnDayService : DayService
{
    protected const string User = Users.John;
}
```

5. Create a new folder inside Services/John called DayServices. In here, create DayOneService.cs and extend the following:

```cs
public class DayOneService : JohnDayService, IDayService
```

Ensure you implement the required methods.

## Good to go

Now we're good to go, and the development should essentially go like follows.

- Use the existing FileHelper class inside Helpers to load your puzzle input. It accepts a name and a day, so loading puzzle input is simple.
  - Note: We added our User const at the top of our JohnDayService file. This allows us to simply pass `User` nto these FileHelper methods and load ours every time.
  - Additional note: Passing a 3rd parameter allows you to pass in a method which takes a string and returns any type you wish, in order to convert the result to a list of that type by using your given converter function.

- Use the Helpers project to create static helper methods, as well as Extensions. Everything static.

- Use your given Day service to contain any code relevant to that day that is not going to be reusable stuff.

- Create your own Service sub-structure alongside DayServices in order to make non-static things that you need.

- Use the Domain project to create DTOs and Structs etc.

## Running your code

Once your Day Service methods are filled in and returning string values, you can run your code by going to `Program.cs` in the `App` project and changing the user const at the top to your new user from the Users constant file.

## Notes

- Each user has different input, so no 2 answers will be the same. Make sure you create your own input.
