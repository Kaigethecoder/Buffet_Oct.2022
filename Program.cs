public class Program
{
    public static void Main(string[] args)
    {
        Buffet newBuffet = new Buffet();
        Console.WriteLine("Hello, welcome to our buffet!");
        bool buffet = true;
        while (buffet)
        {
            int people = newBuffet.GetPartyNumber();
            List<Guest> guests = newBuffet.TakeTableOrder(people);
            Console.WriteLine("\nWould you like to split the check?");
            string split = newBuffet.ValidateResponse();
            newBuffet.GiveBill(split, guests);
            Console.WriteLine("\nWould you like to go again?");
            string response = newBuffet.ValidateResponse();
            buffet = newBuffet.EatAgain(response);
        }
    }
    public interface IBuffet
    {
        string ValidateResponse();
        int GetPartyNumber();
        void SeeMenu();
        void AskToSeeMenu();
        List<Guest> TakeTableOrder(int people);
        void GiveBill(string split, List<Guest> guests);
        bool EatAgain(string response);
        string CapitalizeName(string name);
    }
    public class Buffet : IBuffet
    {
        public bool EatAgain(string response)
        {
            bool buffet = true;
            if (response == "Y")
            {
                buffet = true;
                Console.WriteLine("\nGreat!");
            }
            else
            {
                buffet = false;
                Console.WriteLine("\nHave a nice day!");
            }
            return buffet;
        }
        public string CapitalizeName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1);
        }
        public void AskToSeeMenu()
        {
            Console.WriteLine("\nWould you like to see a menu?");
            string response = ValidateResponse();
            if (response == "Y")
            {
                SeeMenu();
            }
        }
        public void SeeMenu()
        {
            decimal soda = 1.50M;
            decimal coffee = 2.00M;
            decimal buffet = 9.99M;
            Console.WriteLine("\n_____________________");
            Console.WriteLine("Drinks");
            Console.WriteLine("---------------------");
            Console.WriteLine(String.Format("{0, -10} | {1, -10}", "Water", "Free"));
            Console.WriteLine(String.Format("{0, -10} | {1, -10}", "Soda", $"${soda}"));
            Console.WriteLine(String.Format("{0, -10} | {1, -10}", "Coffee", $"${coffee}"));
            Console.WriteLine("_____________________");
            Console.WriteLine("\nFood");
            Console.WriteLine("---------------------");
            Console.WriteLine(String.Format("{0, -10} | {1, -10}", "Buffet", $"${buffet}"));
            Console.WriteLine("_____________________");
        }
        public List<Guest> TakeTableOrder(int people)
        {
            List<Guest> guests = new List<Guest>();
            for (int i = 0; i < people; i++)
            {
                AskToSeeMenu();
                var newGuest = new Guest();
                newGuest = newGuest.TakeGuestOrder();
                guests.Add(newGuest);
            }
            return guests;
        }
        public void GiveBill(string split, List<Guest> guests)
        {
            if (split == "Y")
            {
                guests[0].SplitCheck(guests);
            }
            else
            {
                Console.WriteLine($"\nThe total is ${guests[0].GetTotalBill(guests)}.");
            }
        }
        public string ValidateResponse()
        {
            string validResponse = "";
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("Please enter y for yes and n for no");
                string response = Console.ReadLine();
                if (response.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    validResponse = response.ToUpper();
                    valid = true;
                }
                else if (response.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    validResponse = response.ToUpper();
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("\nI'm sorry, I didn't catch that.");
                }
            }
            return validResponse;
        }
        public int GetPartyNumber()
        {
            bool validParty = false;
            int people = 0;
            while (validParty == false)
            {
                Console.WriteLine("\nHow many people are eating today?  (1-6)");
                string response = Console.ReadLine();
                bool isNum = int.TryParse(response, out people);
                if (isNum)
                {
                    if (people > 0 && people < 7)
                    {
                        validParty = true;
                        Console.WriteLine($"\nGreat!  I'll take you {people} right this way.");
                    }
                    else
                    {
                        validParty = false;
                        Console.WriteLine("\nSorry, we can only serve 1-6 people per party.");
                    }
                }
                else
                {

                    validParty = false;
                    Console.WriteLine("\nI'm sorry, I think I misunderstood your answer.");
                }
            }
            return people;
        }
    }
    public class Guest
    {
        public string Name { get; set; }
        public string drinkChoice { get; set; }
        public decimal totalCost { get; set; }
        public Guest(string newName, string newDrinkChoice, decimal newTotalCost)
        {
            Name = newName;
            drinkChoice = newDrinkChoice;
            totalCost = newTotalCost;
        }
        public Guest()
        {

        }
        public void SplitCheck(List<Guest> guests)
        {
            foreach (Guest guest in guests)
            {
                Console.WriteLine($"\n{guest.Name} owes ${guest.totalCost}.");
            }
        }
        public decimal GetTotalBill(List<Guest> guests)
        {
            decimal totalBill = 0;
            foreach (Guest guest in guests)
            {
                totalBill += guest.totalCost;
            }
            return totalBill;
        }
        public decimal GetTotalCostOfGuest(string drink)
        {
            decimal totalCost = 0;
            if (drink.Equals("water", StringComparison.CurrentCultureIgnoreCase))
            {
                totalCost = 9.99M;
            }
            else if (drink.Equals("coffee", StringComparison.CurrentCultureIgnoreCase))
            {
                totalCost = 11.99M;
            }
            else
            {
                totalCost = 10.49M;
            }
            return totalCost;
        }
        public Guest TakeGuestOrder()
        {
            bool validName = false;
            bool validDrink = false;
            var newGuest = new Guest();
            Buffet newBuffet = new Buffet();
            string guestName = "";
            string drinkChoice = "";
            while (validName == false)
            {
                Console.WriteLine("\nWhat is your name?");
                guestName = Console.ReadLine();
                if (guestName == "")
                {
                    validName = false;
                    Console.WriteLine("\nSorry, I didn't catch that.");
                }
                else
                {
                    validName = true;
                    newGuest.Name = newBuffet.CapitalizeName(guestName);
                }
            }
            if (validName == true)
            {
                do
                {
                    Console.WriteLine("\nWhat would you like to drink?");
                    drinkChoice = Console.ReadLine();
                    var message = $"\nOkay {newGuest.Name}, one {drinkChoice} for you.";
                    if (drinkChoice.Equals("water", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine(message);
                    }
                    else if (drinkChoice.Equals("coffee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine(message);
                    }
                    else if (drinkChoice.Equals("soda", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        validDrink = false;
                        Console.WriteLine("\nSorry, we do not have that.");
                    }
                } while (validDrink == false);
            }
            newGuest.totalCost = newGuest.GetTotalCostOfGuest(newGuest.drinkChoice);
            return newGuest;
        }
    }
}