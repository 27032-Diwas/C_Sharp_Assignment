using System.Text;

namespace Collections.Service;

/// <summary>
/// Reverse the entered word using stack.
/// </summary>
/// <typeparam name="T"> Type of item to be in stack (char). </typeparam>
public class Task2<T>
{
    private readonly Stack<T> _character = new ();

    /// <summary>
    /// Push character to the stack.
    /// </summary>
    /// <param name="word"> Word to add to stack. </param>
    public void AddCharacter(IEnumerable<T> word)
    {
        foreach (T c in word)
        {
            this._character.Push(c);
        }
    }

    /// <summary>
    /// Gets reversed word.
    /// </summary>
    /// <returns> Reversed string of entered word. </returns>
    public string GetReversedWord() => this.RemoveCharacters();

    /// <summary>
    /// Pops character from the stack and append to string.
    /// </summary>
    private string RemoveCharacters()
    {
        var sb = new StringBuilder();

        while (this._character.Any())
        {
            sb.Append(this._character.Pop());
        }

        return sb.ToString();
    }
}
