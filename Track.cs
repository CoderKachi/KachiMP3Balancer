class Track
{
    public string path { get; }
    public string name => System.IO.Path.GetFileName(path);
    public double? loudness = null;

    public Track(string setPath)
    {
        path = setPath;
    }
}