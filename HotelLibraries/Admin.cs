using System;


namespace HotelLib
{
    public class Admin : User
    {
        private static uint _adminIDcounter = 1;
        public Admin(string login, string password, string name)
        {
            Login = login;
            Password = password;
            Name = name;
            UserID = _adminIDcounter;
            try
            {
                BookingHandlerSingleton.Instance.TryAddAdminToDB(this);
            }
            catch (UserException exception)
            {
                throw exception;
            }
            _adminIDcounter++;
        }
    }
}
