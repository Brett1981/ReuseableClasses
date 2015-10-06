namespace Re_useable_Classes.ParentalControl
{
    public class CurrentUserPermissions
    {
        public string UserId { get; set; }
        public int View { get; set; }
        public int Edit { get; set; }
        public int Delete { get; set; }
        public int Duplicate { get; set; }
        public int Approval { get; set; }
    }
}
