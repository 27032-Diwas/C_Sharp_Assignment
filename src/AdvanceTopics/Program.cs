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
        Console.WriteLine("Events and Delegate\n");
        Notifier notifier = new ();
        EventsAndDelegate eventsAndDelegate = new (notifier);
        eventsAndDelegate.Execute();

        GetKey();

        Console.WriteLine("Var and Dynamic\n");
        VarAndDynamic varAndDynamic = new ();
        varAndDynamic.Demonstrate();

        GetKey();

        Console.WriteLine("Anonymous Method\n");
        AnonymousMethod anonymousMethod = new ();
        anonymousMethod.Demonstrate();

        GetKey();

        Console.WriteLine("Lambda Expression\n");
        LambdaExpression lambdaExpression = new ();
        lambdaExpression.Demonstrate();

        GetKey();

        Console.WriteLine("Delegates\n");
        Delegates delegates = new ();
        delegates.Demonstrate();

        GetKey();

        Console.WriteLine("Records\n");
        Records records = new ();
        records.Demonstrate();

        GetKey();

        Console.WriteLine("Pattern Matching\n");
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