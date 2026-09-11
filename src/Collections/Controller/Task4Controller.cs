using Collections.Constants;
using Collections.Enums;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service.
/// </summary>
public class Task4Controller
{
    private readonly IView _view;
    private readonly Task4<string, double> _task4;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task4Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task4"> Instance of task 4 service. </param>
    public Task4Controller(IView view, Task4<string, double> task4)
    {
        this._view = view;
        this._task4 = task4;
    }

    /// <summary>
    /// Gets task 4 menu option.
    /// </summary>
    public void Task4MenuOption()
    {
        while (true)
        {
            try
            {
                Task4Menu choice = this._view.GetMenuChoice<Task4Menu>(MainMenu.Dictionary.ToString(), $"\n{UserPrompts.SelectOption} [ 0 - 3 ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case Task4Menu.Back:
                        return;
                    case Task4Menu.AddStudent:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.AddStudent();
                        break;
                    case Task4Menu.RemoveStudent:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.RemoveStudent();
                        break;
                    case Task4Menu.ViewStudents:
                        this.DisplayStudents();
                        break;
                    default:
                        this._view.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                this._view.GetAnyKey();
            }
            catch (OperationCanceledException)
            {
                this._view.DisplaySuccessMessage(ErrorMessages.ProcessCancelled);
                this._view.GetAnyKey();
            }
            catch (Exception)
            {
                this._view.DisplayErrorMessage(ErrorMessages.ExceptionMessage);
            }
        }
    }

    /// <summary>
    /// Adds student to the list.
    /// </summary>
    private void AddStudent()
    {
        string studentName = this._view.GetStringInput(UserPrompts.GetStudentName);
        double studentMark = this._view.GetDoubleInput(UserPrompts.GetStudentMark);
        this._task4.AddStudent(studentName, studentMark);
        this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulAdditionOfStudent);
    }

    /// <summary>
    /// Removes student from the list.
    /// </summary>
    private void RemoveStudent()
    {
        string studentName = this._view.GetStringInput(UserPrompts.GetStudentName);

        if (this._task4.RemoveStudent(studentName))
        {
            this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfStudent);
            return;
        }

        this._view.DisplayErrorMessage(ErrorMessages.StudentNotFound);
    }

    /// <summary>
    /// Display all students in dictionary.
    /// </summary>
    private void DisplayStudents()
    {
        IReadOnlyDictionary<string, double> students = this._task4.GetStudents();

        if (!students.Any())
        {
            Console.WriteLine(ErrorMessages.EmptyDictionary);
            return;
        }

        foreach (KeyValuePair<string, double> student in students)
        {
            this._view.DisplayMessage($"{student.Key} : {student.Value}");
        }
    }
}
