namespace Re_useable_Classes.SQL
{
    public class ForeignKeyContainer
    {
        public string ParentTable { get; set; }
        public string ParentColumn { get; set; }
        public string ChildColumn { get; set; }
    }
}