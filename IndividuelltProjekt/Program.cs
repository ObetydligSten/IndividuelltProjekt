namespace IndividuelltProjekt
{
    internal class Program
    {       
        //För att håll koll på vem som är inloggad finns dessa globala variabler. En för Namn och en kör kod.
        static string LoggedInUser = null;
        static int LoggedInCode = 0;

        //Dessa ligger som globala variablar så inte summan i kontona ska reseta när man kollar sitt konto.
        static string[] rasmusAName = new string[3] { "SPARKONTO", "LÖNEKONTO", "RESEKONTO" };
        static double[] rasmusASum = new double[3] { 67324.71, 9023.40, 36041.00 };

        static string[] benAName = new string[1] { "SPARKONTO", };
        static double[] benASum = new double[1] { 333333.00 };

        static string[] stenAName = new string[4] { "SPARKONTO", "LÖNEKONTO", "RESEKONTO", "HUSKONTO" };
        static double[] stenASum = new double[4] { 60324.09, 9023.40, 36041.00, 3500400.98 };

        static string[] kurtAName = new string[2] { "SPARKONTO", "LÖNEKONTO" };
        static double[] kurtASum = new double[2] { 999666.16, 31432.40 };

        static string[] svenAName = new string[5] { "SPARKONTO", "LÖNEKONTO", "RESEKONTO", "HUSKONTO", "MATKONTO" };
        static double[] svenASum = new double[5] { 156314.93, 6400.02, 3.00, 11111.75, 3377.90 };

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
                if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
                {
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
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, skriv in en siffra. . .");
                    Console.ReadKey();
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
                        //.ToString("0.00") formaterar om saldot till att visa två decimaler.
                        Console.WriteLine(rasmusASum[i].ToString("0.00") + " SEK");
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
                        Console.WriteLine(rasmusASum[i].ToString("0.00") + " SEK");
                    }
                    //Sparar kontonamen användaren vill flytta pengar mellan och gör om det till stora bokstäver
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    string accountTo = Console.ReadLine().ToUpper();
                    //For-loop som kontrollerar ifall kontonnamen exiserar
                    for (int i = 0; i < rasmusAName.Length; i++)
                    {
                        if (accountFrom == rasmusAName[i])
                        {
                            for (int j = 0; j < rasmusAName.Length; j++)
                            {
                                if (accountTo == rasmusAName[j] && accountTo != accountFrom)
                                {
                                    //Användaren skriver in hur mycket som ska föras över
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    //programmet kontrollerar ifall det går att föra över denna summan utan att ett saldo blir mindre än 0.
                                    if (transfer > 0 && (rasmusASum[i] - transfer) >= 0 && (rasmusASum[j] + transfer) >= 0)
                                    {
                                        rasmusASum[i] -= transfer;
                                        rasmusASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{rasmusAName[i]}: {rasmusASum[i].ToString("0.00")}" +
                                            $" SEK\n{rasmusAName[j]}: {rasmusASum[j].ToString("0.00")}" +
                                            $" SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();                                       
                                        Menu();
                                    }
                                    //Några olika felmeddelanden ifall någonting i transaktionen skulle bli fel.
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
                        Console.WriteLine(rasmusASum[i].ToString("0.00") + " SEK");
                    }
                    //Användaren skriver in vilket konto som pengar ska tas från, och kontrolleras ifall detta konto finns.
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    for (int i = 0;i < rasmusAName.Length;i++)
                    {
                        if (accountFrom == rasmusAName[i])
                        {
                            //användaren anger hur mycket som ska tas ut och bekräftar genom att skriva in sin pinkod
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                //Summan och kontonamnet kontrolleras, om allt stämmer görs uttaget.
                                if (transfer > 0 && (rasmusASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    rasmusASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{rasmusAName[i]}: {rasmusASum[i].ToString("0.00")} SEK" +
                                        $"\n\nTryck ENTER för att gå tillbaka till menyn");
                                    Console.ReadKey();
                                    Menu();
                                }
                                //Några fel meddelande ifall någon skulle vara fel.
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
                    
            //Identiskt med ovanstående if sats bortsätt från att det nu är Ben's konton istället
            }
            else if (user == "Ben")
            {
                if (menuChoiceCheck == 1)
                {
                    //En loop som skriver ut alla konton för den inloggade användaren
                    Console.WriteLine("\nKonton och Saldon: \n");
                    for (int i = 0; i < benAName.Length; i++)
                    {
                        Console.Write(benAName[i] + ": ");
                        Console.WriteLine(benASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn. . .");
                    Console.ReadKey();
                    Menu();
                }
                else if (menuChoiceCheck == 2)
                {
                    Console.WriteLine("\nÖverföring mellan konton: \n");
                    for (int i = 0; i < benAName.Length; i++)
                    {
                        Console.Write(benAName[i] + ": ");
                        Console.WriteLine(benASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    string accountTo = Console.ReadLine().ToUpper();
                    for (int i = 0; i < benAName.Length; i++)
                    {
                        if (accountFrom == benAName[i])
                        {
                            for (int j = 0; j < benAName.Length; j++)
                            {
                                if (accountTo == benAName[j] && accountTo != accountFrom)
                                {
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    if (transfer > 0 && (benASum[i] - transfer) >= 0 && (benASum[j] + transfer) >= 0)
                                    {
                                        benASum[i] -= transfer;
                                        benASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{benAName[i]}: {benASum[i].ToString("0.00")}" +
                                            $" SEK\n{benAName[j]}: {benASum[j].ToString("0.00")}" +
                                            $" SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if (transfer < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra en negativ summa");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if ((benASum[i] - transfer) < 0)
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
                    for (int i = 0; i < benAName.Length; i++)
                    {
                        Console.Write(benAName[i] + ": ");
                        Console.WriteLine(benASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    for (int i = 0; i < benAName.Length; i++)
                    {
                        if (accountFrom == benAName[i])
                        {
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                if (transfer > 0 && (benASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    benASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{benAName[i]}: {benASum[i].ToString("0.00")} SEK" +
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
                                else if ((benASum[i] - transfer) < 0)
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

            //Likadan som ovan men den har Sten's konton istället
            else if ( user == "Sten")
            {
                if (menuChoiceCheck == 1)
                {
                    //En loop som skriver ut alla konton för den inloggade användaren
                    Console.WriteLine("\nKonton och Saldon: \n");
                    for (int i = 0; i < stenAName.Length; i++)
                    {
                        Console.Write(stenAName[i] + ": ");
                        Console.WriteLine(stenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn. . .");
                    Console.ReadKey();
                    Menu();
                }
                else if (menuChoiceCheck == 2)
                {
                    Console.WriteLine("\nÖverföring mellan konton: \n");
                    for (int i = 0; i < stenAName.Length; i++)
                    {
                        Console.Write(stenAName[i] + ": ");
                        Console.WriteLine(stenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    string accountTo = Console.ReadLine().ToUpper();
                    for (int i = 0; i < stenAName.Length; i++)
                    {
                        if (accountFrom == stenAName[i])
                        {
                            for (int j = 0; j < stenAName.Length; j++)
                            {
                                if (accountTo == stenAName[j] && accountTo != accountFrom)
                                {
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    if (transfer > 0 && (stenASum[i] - transfer) >= 0 && (stenASum[j] + transfer) >= 0)
                                    {
                                        stenASum[i] -= transfer;
                                        stenASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{stenAName[i]}: {stenASum[i].ToString("0.00")}" +
                                            $" SEK\n{stenAName[j]}: {stenASum[j].ToString("0.00")}" +
                                            $" SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if (transfer < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra en negativ summa");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if ((stenASum[i] - transfer) < 0)
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
                    for (int i = 0; i < stenAName.Length; i++)
                    {
                        Console.Write(stenAName[i] + ": ");
                        Console.WriteLine(stenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    for (int i = 0; i < stenAName.Length; i++)
                    {
                        if (accountFrom == stenAName[i])
                        {
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                if (transfer > 0 && (stenASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    stenASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{stenAName[i]}: {stenASum[i].ToString("0.00")} SEK" +
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
                                else if ((stenASum[i] - transfer) < 0)
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

            //Likadan som ovan men den har Kurt's konton istället
            else if (user == "Kurt")
            {
                if (menuChoiceCheck == 1)
                {
                    //En loop som skriver ut alla konton för den inloggade användaren
                    Console.WriteLine("\nKonton och Saldon: \n");
                    for (int i = 0; i < kurtAName.Length; i++)
                    {
                        Console.Write(kurtAName[i] + ": ");
                        Console.WriteLine(kurtASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn. . .");
                    Console.ReadKey();
                    Menu();
                }
                else if (menuChoiceCheck == 2)
                {
                    Console.WriteLine("\nÖverföring mellan konton: \n");
                    for (int i = 0; i < kurtAName.Length; i++)
                    {
                        Console.Write(kurtAName[i] + ": ");
                        Console.WriteLine(kurtASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    string accountTo = Console.ReadLine().ToUpper();
                    for (int i = 0; i < kurtAName.Length; i++)
                    {
                        if (accountFrom == kurtAName[i])
                        {
                            for (int j = 0; j < kurtAName.Length; j++)
                            {
                                if (accountTo == kurtAName[j] && accountTo != accountFrom)
                                {
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    if (transfer > 0 && (kurtASum[i] - transfer) >= 0 && (kurtASum[j] + transfer) >= 0)
                                    {
                                        kurtASum[i] -= transfer;
                                        kurtASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{kurtAName[i]}: {kurtASum[i].ToString("0.00")}" +
                                            $" SEK\n{kurtAName[j]}: {kurtASum[j].ToString("0.00")}" +
                                            $" SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if (transfer < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra en negativ summa");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if ((kurtASum[i] - transfer) < 0)
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
                    for (int i = 0; i < kurtAName.Length; i++)
                    {
                        Console.Write(kurtAName[i] + ": ");
                        Console.WriteLine(kurtASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    for (int i = 0; i < kurtAName.Length; i++)
                    {
                        if (accountFrom == kurtAName[i])
                        {
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                if (transfer > 0 && (kurtASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    kurtASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{kurtAName[i]}: {kurtASum[i].ToString("0.00")} SEK" +
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
                                else if ((kurtASum[i] - transfer) < 0)
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

            //Likadan som ovan men den har Sven's konton istället
            else if (user == "Sven")
            {
                if (menuChoiceCheck == 1)
                {
                    //En loop som skriver ut alla konton för den inloggade användaren
                    Console.WriteLine("\nKonton och Saldon: \n");
                    for (int i = 0; i < svenAName.Length; i++)
                    {
                        Console.Write(svenAName[i] + ": ");
                        Console.WriteLine(svenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn. . .");
                    Console.ReadKey();
                    Menu();
                }
                else if (menuChoiceCheck == 2)
                {
                    Console.WriteLine("\nÖverföring mellan konton: \n");
                    for (int i = 0; i < svenAName.Length; i++)
                    {
                        Console.Write(svenAName[i] + ": ");
                        Console.WriteLine(svenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilka konton vill du överföra pengar mellan?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    string accountTo = Console.ReadLine().ToUpper();
                    for (int i = 0; i < svenAName.Length; i++)
                    {
                        if (accountFrom == svenAName[i])
                        {
                            for (int j = 0; j < svenAName.Length; j++)
                            {
                                if (accountTo == svenAName[j] && accountTo != accountFrom)
                                {
                                    Console.WriteLine($"\nÖverför pengar från {accountFrom} till {accountTo}. \nHur mycket vill du överföra?");
                                    Double.TryParse(Console.ReadLine(), out double transfer);
                                    if (transfer > 0 && (svenASum[i] - transfer) >= 0 && (svenASum[j] + transfer) >= 0)
                                    {
                                        svenASum[i] -= transfer;
                                        svenASum[j] += transfer;
                                        Console.WriteLine($"Överföring klar, nytt saldo är: \n\n{svenAName[i]}: {svenASum[i].ToString("0.00")}" +
                                            $" SEK\n{svenAName[j]}: {svenASum[j].ToString("0.00")}" +
                                            $" SEK\n\nTryck ENTER för att gå tillbaka till menyn ");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if (transfer < 0)
                                    {
                                        Console.WriteLine("Kan inte överföra en negativ summa");
                                        Console.ReadKey();
                                        Menu();
                                    }
                                    else if ((svenASum[i] - transfer) < 0)
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
                    for (int i = 0; i < svenAName.Length; i++)
                    {
                        Console.Write(svenAName[i] + ": ");
                        Console.WriteLine(svenASum[i].ToString("0.00") + " SEK");
                    }
                    Console.WriteLine("\nVilket Konto vill du ta ut pengar från?");
                    string accountFrom = Console.ReadLine().ToUpper();
                    for (int i = 0; i < svenAName.Length; i++)
                    {
                        if (accountFrom == svenAName[i])
                        {
                            Console.WriteLine("Hur mycket pengar vill du ta ut?");
                            Double.TryParse(Console.ReadLine(), out double transfer);
                            Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget");
                            if (Int32.TryParse(Console.ReadLine(), out int codeCheck))
                            {
                                if (transfer > 0 && (svenASum[i] - transfer) >= 0 && codeCheck == LoggedInCode)
                                {
                                    svenASum[i] -= transfer;
                                    Console.WriteLine($"Uttag klart, nya saldot är \n\n{svenAName[i]}: {svenASum[i].ToString("0.00")} SEK" +
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
                                else if ((svenASum[i] - transfer) < 0)
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
        }   
    }
}