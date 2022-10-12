# Buffet_Oct.2022
 > Buffet is a simple project created in Visual Studio 6.0 using a C# Console App.
 
 ## Project Description
 - The Buffet project welcomes the user to the buffet, asks them how many will be eating, takes individual orders and prints the bill how they user wishes.
 - The user can repeat this process as many times as they like.
 
 ## Breakdown of Classes & Interfaces
 - public interface IBuffet declares 8 methods to be used by child classes.
 - public class Buffet inherits methods from IBuffet interface.
 - public class Guest has properties string Name, string drinkChoice and decimal totalCost, a no arguments constructor as well as several methods.
 
 ## Breakdown of Methods
 > Buffet Class
 - bool EatAgain(string response)  Objective: Determine whether or not to repeat process.
 - string CapitalizeName(string name)  Objective: Ensure user input has proper punctuation when called.
 - void AskToSeeMenu()  Objective: Show menu to Guest if requested.
 - void SeeMenu()  Objective: Display food and drink prices in proper format to give real menu feeling.
 - List<Guest> TakeTableOrder(int people)  Objective: Show menu if needed and create the right amount of guests while taking their order.
 - void GiveBill(string split, List<Guest> guests) Objective: Display bill depending on users preference(split or altogether).
 - string ValidateResponse() Objective: Get proper yes or no response.  (Y for yes or N for no).
 - int GetPartyNumber() Objective: Get valid number within party size limits(1 minimum, 6 maximum).
 > Guest Class
 - void SplitCheck(List<Guest> guests) Objective: Display each guests name and what they owe.
 - decimal GetTotalBill(List<Guest> guests) Objective: Loop through each Guest and add the total cost of each to get the total bill.
 - decimal GetTotalCostOfGuest(string drink) Objective: Assume everyone eats for $9.99 and add the cost of their drink to get total cost for the Guest.
 - Guest TakeGuestOrder() Objective: Get valid name(capitalized) and a valid drink choice then calculate the total cost for the guest.
 
 ## Stretch Goals
 > Since this is just a simple program to demonstrate my growth in C#, there are a few things I did not get to do such as:
 - Drink Class 
 - int age for Guest property so kids could possibly eat free.  Would need to update methods accordingly.
 - Clean up Program class for better readability.
 
 ## Skills Demonstrated
 - C#
 - OOP
 - User Input
 - Conditionals
 - Design Patterns
