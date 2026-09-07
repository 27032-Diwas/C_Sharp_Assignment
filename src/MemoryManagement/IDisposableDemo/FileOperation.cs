namespace IDisposableDemo;

/// <summary>
/// Writes content into the file and dispose the file.
/// </summary>
public class FileOperation : IDisposable
{
    private readonly string _filePath;
    private readonly StreamWriter _writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileOperation"/> class.
    /// </summary>
    /// <param name="filePath"> File path. </param>
    public FileOperation(string filePath)
    {
        this._filePath = filePath;
        this._writer = new StreamWriter(filePath);
    }

    /// <summary>
    /// Write the content into the file.
    /// </summary>
    /// <param name="content"> Content to be written in file. </param>
    public void Write(string content)
    {
        this._writer.Write(content);
    }

    /// <summary>
    /// Dispose the file stream.
    /// </summary>
    public void Dispose()
    {
        this._writer.Dispose();
    }
}
