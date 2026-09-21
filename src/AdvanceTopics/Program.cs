using AdvanceTopics;
using AdvanceTopics.Tasks;
using System.Runtime.CompilerServices;

namespace Assignments;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application.
    /// </summary>
    public static void Main()
    {
        Notifier notifier = new ();
        EventsAndDelegate eventsAndDelegate = new (notifier);
        eventsAndDelegate.Execute();

        GetKey();

        VarAndDynamic varAndDynamic = new ();
        varAndDynamic.Demonstrate();

        GetKey();

        AnonymousMethod anonymousMethod = new ();
        anonymousMethod.Demonstrate();

        GetKey();

        LambdaExpression lambdaExpression = new ();
        lambdaExpression.Demonstrate();

        GetKey();

        Delegates delegates = new ();
        delegates.Demonstrate();

        GetKey();

        Records records = new ();
        records.Demonstrate();

        GetKey();

        PatternMatching patternMatching = new ();
        patternMatching.Demonstrate();

        GetKey();
    }

    /// <summary>
    /// Gets key and clear the console.
    /// </summary>
    public static void GetKey()
    {
        Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }
}