using AdvanceTopics;
using AdvanceTopics.Tasks;

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

        VarAndDynamic varAndDynamic = new ();
        varAndDynamic.Demonstrate();

        AnonymousMethod anonymousMethod = new ();
        anonymousMethod.Demonstrate();

        LambdaExpression lambdaExpression = new ();
        lambdaExpression.Demonstrate();

        Console.ReadKey();
    }
}