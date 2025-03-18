namespace Probability;

internal class Program
{
    private static Random _rnd = new Random();
    private static int _scopeLow = 0;
    private static int _scopeHigh = 5000;
    private static int _goal = 4;
    private static int _currentScore = 0;
    private static int _index;

    private static int _desiredRangeLow = 0;
    private static int _desiredRangeHigh = 10;

    private static ulong _iterations = 0;

    private static int _startingQuestions = 40;
    private static int _amountOfQuestions = _startingQuestions;
    private static int _guessedAnswer;

    private static decimal _chance = 1.00m;

    public static decimal CalculateTheChanceOfPassingFirstTry()
    {
        for (int i = 0; i <= _startingQuestions; i++)
        {
            _chance *= 0.5m;
        }

        return _chance * 100m;
    }
    
    
    private static async Task StartGambling()
    {
        await Task.Run(() =>
        {
            while (true)
            {
                _iterations++;
                _index = _rnd.Next(_scopeLow, _scopeHigh+1);
                if (_index >= _desiredRangeLow && _index <= _desiredRangeHigh)
                {
                    _currentScore++;

                }
                else
                {

                    _currentScore = 0;
                }

                if (_currentScore == _goal)
                {
                    Console.WriteLine("Finished, with " + _iterations + " iterations");
                    break;
                }
            
            }
        });
    }

    private static async Task TakeTheTest()
    {
        await Task.Run(() =>
        {
            while (true)
            {
                _iterations++;
                _guessedAnswer = _rnd.Next(1, 3);

                if (_guessedAnswer == 1)
                {
                    _amountOfQuestions--;
                }
                else
                {
                    _amountOfQuestions = _startingQuestions;
                }

                if (_amountOfQuestions == 0) 
                {
                    Console.WriteLine("Passed the test, with " + _iterations + " iterations");
                    Console.WriteLine(CalculateTheChanceOfPassingFirstTry() + "%");
                    break;
                }
            }
        });
    }

    

    private static async Task Main(string[] args)
    {
        Task task1 = TakeTheTest();
        await Task.WhenAll(task1);
    }
}