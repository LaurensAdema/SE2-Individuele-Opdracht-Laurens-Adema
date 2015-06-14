namespace Tweakers
{
    using System;

    public class Admin: Account
    {
        public Admin(int userId, string username, string email, int tweakotine, int karma, DateTime birthdate, string city, char gender, int adminId, string fullName)
            : base(userId, username, email, tweakotine, karma, birthdate, city, gender)
        {
            this.AdminID = adminId;
            this.FullName = fullName;
        }

        public int AdminID { get; set; }

        public string FullName { get; set; }
    }
}
