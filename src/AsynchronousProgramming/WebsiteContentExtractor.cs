namespace AsynchronousProgramming;

/// <summary>
/// Provides functionality to download website content asynchronously.
/// </summary>
public class WebsiteContentExtractor
{
    /// <summary>
    /// Shared HttpClient instance.
    /// </summary>
    private static readonly HttpClient HttpClient = new ();

    /// <summary>
    /// Downloads content from the specified URL.
    /// </summary>
    /// <param name="url">Website URL.</param>
    /// <returns>Downloaded content.</returns>
    /// <exception cref="HttpRequestException">
    /// Thrown when the request fails.
    /// </exception>
    public async Task<string> ExtractContent(string url)
    {
        try
        {
            string content = await HttpClient.GetStringAsync(url);

            Console.WriteLine("Content extraction completed.");

            return content;
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException(
                $"Failed to retrieve content from '{url}'.",
                ex);
        }
    }
}