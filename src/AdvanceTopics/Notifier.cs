namespace AdvanceTopics;

/// <summary>
/// Contains notify event and delegate.
/// </summary>
public class Notifier
{
    /// <summary>
    /// Delegate to notifier.
    /// </summary>
    /// <param name="sender"> Instance of sender. </param>
    /// <param name="message"> Message. </param>
    public delegate void Notify(object sender, string message);

    /// <summary>
    /// Event to notify people.
    /// </summary>
    public event Notify? OnAction;

    /// <summary>
    /// Invoke the event.
    /// </summary>
    /// <param name="message"> Message. </param>
    public void TriggerOnAction(string message)
    {
        this.OnAction?.Invoke(this, message);
    }
}
