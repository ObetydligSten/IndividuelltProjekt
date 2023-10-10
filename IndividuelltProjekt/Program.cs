namespace IndividuelltProjekt
{
    internal class Program
    {       
        //För att håll koll på vem som är inloggad finns dessa globala variabler. En för Namn och en kör kod.
        static string LoggedInUser = null;
        static int LoggedInCode = 0;

        //Dessa ligger som globala variablar så inte summan i kontona ska reseta när man kollar sitt konto.
        static string[] rasmusAName = new string[3] { "Sparkonto", "Lönekonto", "Resekonto" };
        static double[] rasmusASum = new double[3] { 67324.71, 9023.40, 36041.00 };

        static string[] benAName = new string[1] { "Sparkonto", };
        static double[] benASum = new double[1] { 333333.00 };

        static string[] stenAName = new string[4] { "Sparkonto", "Lönekonto", "Resekonto", "Huskonto" };
        static double[] stenASum = new double[4] { 60324.09, 9023.40, 36041.00, 3500000 };

        static string[] kurtAName = new string[2] { "Sparkonto", "Lönekonto" };
        static double[] kurtASum = new double[2] { 999666.16, 31432.40 };

        static string[] svenAName = new string[3] { "Sparkonto", "Lönekonto", "Resekonto" };
        static double[] svenASum = new double[3] { 156314.93, 6400.02, 3.00 };

        static void Main(string[] args)
        {
            Login();
        }


        //Metod för inloggning
        static void Login()
        {            

            //användare och deras pinkod ligger i arrayer.
            string[] users = new string[5] { "Rasmus", "Ben", "Sten", "Kurt", "Sven" };
            int[] passcode = new int[5] { 2345, 1234, 9999, 6677, 9090 };
            bool userFound = false;

            //En for-loop som håller koll på antalet försök kvar.
            for (int i = 3; i > 0;)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till banken!\n");
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
                            LoggedInCode = code;
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
        //Metod för menyn
        static void Menu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Inloggad som " + LoggedInUser + "\n");
                Console.WriteLine("[1] Se dina konton och saldo");
                Console.WriteLine("[2] Överföring mellan konton");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Logga ut");
                int menuChoice = Convert.ToInt32(Console.ReadLine());

                //Varje case skickar till accounts metoden vem som är inloggad och vilket menyval som gjordes.
                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Inloggad som " + LoggedInUser);
                        Accounts(LoggedInUser, menuChoice);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Inloggad som " + LoggedInUser);
                        Accounts(LoggedInUser, menuChoice);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Inloggad som " + LoggedInUser);
                        Accounts(LoggedInUser, menuChoice);
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

        //En metod som behandlar alla konton.
        static void Accounts(string user, int menuChoiceCheck)
        {
            
            //Kontrollerar vilken användare som är inloggad och sedan även vilket menyval som gjordes.
            if (user == "Rasmus") 
            {
                
                if (menuChoiceCheck == 1)
                {
                    //En loop som skriver ut alla konton för den inloggade användaren
                    Console.WriteLine("\nKonton och Saldon: \n");
                    for (int i = 0; i < rasmusAName.Length; i++)
                    {
                        Console.Write(rasmusAName[i] + ": ");
                        Console.WriteLine(rasmusASum[i] + " SEK");
                    }
                    Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn. . .");
                    Console.ReadKey();
                    Menu();
                }
                else if (menuChoiceCheck == 2)
                {
                    Console.WriteLine("\nÖverföring mellan konton: \n");
                    for (int i = 0; i < rasmusAName.Length; i++)
                    {
                        Console.Write(rasmusAName[i] + ": ");
                        Console.WriteLine(rasmusASum[i] + " SEK");
                    }
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine();
                    string accountTo = Console.ReadLine();
                    for (int i = 0; i < rasmusAName.Length; i++)
                    {
                        if (accountFrom == rasmusAName[i])
                        {
                            for (int j = 0; j < rasmusAName.Length; j++)
                            {
                                if (accountTo == rasmusAName[j] && accountTo != accountFrom)
                                {
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    if (transfer > 0 && (rasmusASum[i] - transfer) >= 0 && (rasmusASum[j] + transfer) >= 0)
                                    {
                                        rasmusASum[i] -= transfer;
                                        rasmusASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{rasmusAName[i]}: {rasmusASum[i]} SEK" +
                                            $"\n{rasmusAName[j]}: {rasmusASum[j]} SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();                                       
                                        Menu();
                                    }
                                    else if (transfer < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra en negativ summa");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if ((rasmusASum[i] - transfer) < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra mer pengar än det finns på kontot");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("OBS! Någon gick fel, vänlig försök igen. . .");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    
                                    
                                }
                                else if (accountTo == accountFrom)
                                {
                                    Console.WriteLine("Kan inte vara samma konto, välj olika konton. . .");
                                    Console.ReadKey();
                                    Menu();
                                }
                            }
                        }                        
                    }
                    Console.WriteLine("Kontot hittades inte, försök igen. . .");
                    Console.ReadKey();
                    Menu();



                }
                else if (menuChoiceCheck == 3)
                {
                    Console.WriteLine("\nTa ut pengar\n");
                    for (int i = 0; i < rasmusAName.Length; i++)
                    {                        
                        Console.Write(rasmusAName[i] + ": ");
                        Console.WriteLine(rasmusASum[i] + " SEK");
                    }
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine();
                    for (int i = 0;i < rasmusAName.Length;i++)
                    {
                        if (accountFrom == rasmusAName[i])
                        {
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                if (transfer > 0 && (rasmusASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    rasmusASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{rasmusAName[i]}: {rasmusASum[i]} SEK" +
                                        $"\n\nTryck ENTER för att gå tillbaka till menyn");
                                    Console.ReadKey();
                                    Menu();
                                }
                                else if (transfer < 0)
                                {
                                    Console.WriteLine("Kan inte överföra en negativ summa");
                                    Console.ReadKey();
                                    Menu();
                                }
                                else if ((rasmusASum[i] - transfer) < 0)
                                {
                                    Console.WriteLine("Kan inte överföra mer pengar än det finns på kontot");
                                    Console.ReadKey();
                                    Menu();
                                }
                                else if (codeCheck != LoggedInCode)
                                {
                                    Console.WriteLine("OBS, Fel pinkod, försök igen");
                                    Console.ReadKey();
                                    Menu();
                                }
                                else
                                {
                                    Console.WriteLine("OBS! Någon gick fel, vänlig försök igen. . .");
                                    Console.ReadKey();
                                    Menu();
                                }
                            }
                            else 
                            {
                                Console.WriteLine("OBS, Fyrsiffrig kod, försök igen");
                                Console.ReadKey();
                                Menu();
                            }

                           
                        }                       
                    }
                    Console.WriteLine("Hittar inget konto med det namnet, försök igen. . .");
                    Console.ReadKey();
                    Menu();
                }
                    

            }
            else if (user == "Ben")
            {

            }
            else if ( user == "Sten")
            {

            }
            else if (user == "Kurt")
            {

            }
            else if (user == "Sven")
            {

            }
        }   
        





    }
}