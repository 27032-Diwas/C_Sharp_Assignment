using Collections.Constants;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service.
/// </summary>
public class Task6Controller
{
    private readonly IView _view;
    private readonly Task6 _task6;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task6Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task6"> Instance of task 6 service. </param>
    public Task6Controller(IView view, Task6 task6)
    {
        this._view = view;
        this._task6 = task6;
    }

    /// <summary>
    /// Calculate the sum of numbers.
    /// </summary>
    public void SumOfNumbers()
    {
        IEnumerable<int> numbers = this.GetNumbers();

        int sumList = this._task6.SumOfElements(numbers.ToList());
        int sumQueue = this._task6.SumOfElements(numbers.AsQueryable());
        int sumArray = this._task6.SumOfElements(numbers.ToArray());

        this._view.DisplayMessage($"{SuccessMessages.SumOfNumbers} {sumList}, {sumQueue}, {sumArray}");

        this._view.GetAnyKey();
    }

    /// <summary>
    /// Gets numbers from the user.
    /// </summary>
    /// <returns>A list of numbers entered by the user.</returns>
    private IEnumerable<int> GetNumbers()
    {
        int count;

        do
        {
            count = this._view.GetIntegerInput(UserPrompts.GetNumberCount);

            if (count <= 0)
            {
                this._view.DisplayErrorMessage(ErrorMessages.InvalidCount);
            }
        }
        while (count <= 0);

        List<int> numbers = new (count);
        Queue<int> queue = new (count);
        int[] array = new int[count];

        for (int i = 0; i < count; i++)
        {
            int number = this._view.GetIntegerInput(UserPrompts.GetNumber);
            numbers.Add(number);
            queue.Enqueue(number);
            array[i] = number;
        }

        return numbers;
    }
}
