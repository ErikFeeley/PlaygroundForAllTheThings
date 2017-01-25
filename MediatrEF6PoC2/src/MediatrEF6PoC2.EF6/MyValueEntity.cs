namespace MediatrEF6PoC2.EF6
{
    /// <summary>
    /// With this setup we need to have seperate model entities for our context since the .csproj cannot reference a .xproj project. also we would want this seperation anyway
    /// for a domain driven model.
    /// </summary>
    public class MyValueEntity
    {
        public int Id { get; set; }

        public string Blurb { get; set; }
    }
}
