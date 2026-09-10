using Collections.Constants;
using Collections.Enums;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service.
/// </summary>
public class Task2Controller
{
    private readonly IView _view;
    private readonly Task2<char> _task2;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task2Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task2"> Instance of task 2 service. </param>
    public Task2Controller(IView view, Task2<char> task2)
    {
        this._view = view;
        this._task2 = task2;
    }

    /// <summary>
    /// Reverse the word.
    /// </summary>
    public void ReverseWord()
    {
        this.GetWord();
        this._view.DisplayMessage(this._task2.GetReversedWord());
        this._view.GetAnyKey();
    }

    /// <summary>
    /// Get word from user.
    /// </summary>
    private void GetWord()
    {
        this._task2.AddCharacter(this._view.GetStringInput(UserPrompts.GetWord));
    }
}
