using ConsoleAppFrontEnd.Resource.User;

namespace ConsoleAppFrontEnd.Controller
{
    public class UserInteractionProcessor
    {
        public bool TryParseUserFeedback(string text, out string result)
        {
            result = null;

            try
            {
                if (int.TryParse(text, out int ret))
                {
                    result = ret.ToString();

                    if (result == ResourceUserFeedback.AnswerToGet10Pockemons || result == ResourceUserFeedback.AnswerToGetOnlyOnePockemon)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}