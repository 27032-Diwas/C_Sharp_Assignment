namespace Assignments;

/// <summary>
/// Contains logic to allocate memory.
/// </summary>
internal class MemoryEater
{
    /// <summary>
    /// Allocates memory and adds it to a list.
    /// </summary>
    public void Allocate()
    {
        List<int[]> memAlloc = new ();
        int[] list = new int[1000];
        while (true)
        {
            memAlloc.Add(list);

            // Assume memAlloc variable is used within the loop.
            Thread.Sleep(10);
        }
    }
}