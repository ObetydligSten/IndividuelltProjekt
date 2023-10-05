namespace IndividuelltProjekt
{
    internal class Program
    {       
            //För att håll koll på vem som är inloggad finns denna globala variabel.
            static string LoggedInUser = null;

            static void Main(string[] args)
            {
                Login();
            }


            //Metod för inloggning
            static void Login()
            {
                Console.WriteLine("Välkommen till banken!\n");

                //användare och deras pinkod ligger i arrayer.
                string[] users = new string[5] { "Rasmus", "Olof", "Sten", "Kurt", "Sven" };
                int[] passcode = new int[5] { 2345, 1234, 9999, 6677, 9090 };
                bool userFound = false;

                //En for-loop som håller koll på antalet försök kvar.
                for (int i = 3; i > 0;)
                {
                    Console.Clear();
                    Console.Write("Ange användarnamn: ");
                    var username = Console.ReadLine();
                    Console.Write("Ange pinkod: ");
                    if (Int32.TryParse(Console.ReadLine(), out int code))
                    {
                        //En for-loop med en if-sats inuti som kontrollerar om
                        //användarens input stämmer överrens med de användarnamn och pinkod som ligger sparade.
                        for (int j = 0; j < users.Length; j++)
                        {
                            //Båda måste stämma för samma plats för att loggas in.
                            if (users[j] == username && passcode[j] == code)
                            {
                                Console.WriteLine($"Inloggning lyckades: Välkommen {username}!");
                                Console.ReadKey();
                                LoggedInUser = username;
                                userFound = true;
                                Menu();
                                break;
                            }
                        }
                        //Felmeddelande skrivs ut om användarnamnet eller pinkoden inte stämmer överrens.
                        if (userFound == false)
                        {
                            Console.WriteLine("Fel användarnamn eller pinkod. . .");
                            Console.WriteLine("Försök igen");
                            Console.WriteLine($"Du har {i - 1} försök kvar. . .");
                            i--;
                            Console.ReadKey();
                        }
                        else
                        {
                            break;
                        }

                    }
                    //Detta räknas inte som ett försök att logga in, bara säkrar upp ifall användaren skulle mata in något som inte är en siffra i pinkoden.
                    else
                    {
                        Console.WriteLine("Pinkoden består av siffror");
                        Console.ReadKey();
                    }

                }
            }
            static void Menu()
            {
                bool menu = true;
                while (menu)
                {
                    Console.Clear();
                    Console.WriteLine("Inloggad som " + LoggedInUser);
                    Console.WriteLine("[1] Se dina konton och saldo");
                    Console.WriteLine("[2] Överföring mellan konton");
                    Console.WriteLine("[3] Ta ut pengar");
                    Console.WriteLine("[4] Logga ut");
                    int menuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (menuChoice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Inloggad som " + LoggedInUser);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Inloggad som " + LoggedInUser);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Inloggad som " + LoggedInUser);
                            break;
                        case 4:
                            Console.WriteLine("Du loggas ut. . .");
                            Console.ReadKey();
                            Login();
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, skriv in en siffra [1-4]. . .");
                            break;
                    }
                }
            }







        }
    }