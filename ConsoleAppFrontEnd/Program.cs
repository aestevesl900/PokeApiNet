using ConsoleAppFrontEnd.Controller;
using ConsoleAppFrontEnd.Resource.Messages;
using ConsoleAppFrontEnd.Resource.User;
using PokeApiNet;
using System;
using System.Threading.Tasks;

namespace ConsoleAppFrontEnd
{
    internal class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine(ResourceMessages.WellcomeMessageToProceed);
            var consoleText = Console.ReadLine();

            if (UserInteractionProcessor.TryParseUserFeedback(consoleText, out var result))
            {
                if (result == ResourceUserFeedback.AnswerToGet10Pockemons)
                {
                    foreach (var prockemon in await UserSelectionProcessor.GetTopTenPockemonsAsync())
                    {
                        PrintPockemon(prockemon);
                    }

                    await Main(args);
                }
                else if (result == ResourceUserFeedback.AnswerToGetOnlyOnePockemon)
                {
                    Console.WriteLine(ResourceMessages.PockemonIdMessage);
                    string userFeedbackText = Console.ReadLine();

                    if (int.TryParse(userFeedbackText, out var pockemonParsedId))
                    {
                        PrintPockemon(await UserSelectionProcessor.GetPockemonsByIdAsync(pockemonParsedId));

                        await Main(args);
                    }
                    else
                    {
                        Console.WriteLine(ResourceMessages.PockemonWrongId);
                    }
                }
            }
            else
            {
                return await Main(args);
            }

            return 0;
        }

        private static void PrintPockemon(Pokemon pokemon)
        {
            Console.WriteLine(pokemon);            
        }

        private static async Task<bool> TryProcessUserFeedbackByIdAsync()
        {
            Console.WriteLine(ResourceMessages.PockemonIdMessage);

            string userFeedbackText = Console.ReadLine();

            if (int.TryParse(userFeedbackText, out var pockemonParsedId))
            {
                var pocke = await UserSelectionProcessor.GetPockemonsByIdAsync(pockemonParsedId);

                if (pocke != null)
                {
                    Console.WriteLine(pocke);

                    return true;
                }
            }
            else
            {
                Console.WriteLine(ResourceMessages.PockemonWrongId);
            }

            return false;
        }

        private static UserInteractionProcessor UserInteractionProcessor => userInteractionProcessor ??= new UserInteractionProcessor();
        private static UserInteractionProcessor userInteractionProcessor;

        private static UserSelectionProcessor UserSelectionProcessor => userSelectionProcessor ??= new UserSelectionProcessor();
        private static UserSelectionProcessor userSelectionProcessor;
    }
}