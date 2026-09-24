namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstrate delegates and event.
/// </summary>
public class EventsAndDelegate
{
    private readonly Notifier _notifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventsAndDelegate"/> class.
    /// </summary>
    /// <param name="notifier"> Instance of notifier class. </param>
    public EventsAndDelegate(Notifier notifier)
    {
        this._notifier = notifier;
    }

    /// <summary>
    /// Executes the event.
    /// </summary>
    public void Execute()
    {
        this._notifier.OnAction += this.Display;
        this._notifier.TriggerOnAction("Demonstration of events and delegate\n");
        this._notifier.OnAction -= this.Display;
    }

    /// <summary>
    /// Displays the message.
    /// </summary>
    /// <param name="sender"> Sender of event. </param>
    /// <param name="message"> Message to display. </param>
    public void Display(object sender, string message)
    {
        Console.WriteLine(message + sender);
    }
}
