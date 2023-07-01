using CodeChallenge.Implementation;

namespace CodeChallenge.Implementation;

/// <summary>
/// We create an Object user for which we will build the password
/// The password will require the 1 parameter given to the User object and the Current Time using DateTime.now()
/// </summary>
public class User
{
    private int _id { get; set; }

    public User(int id)
    {
        _id = id;
    }

    /// <summary>
    /// method used to generate the password based on the instance of the user
    /// </summary>
    /// <returns>the new password as string</returns>
    public string GeneratePassword()
    {
        return PasswordGenerator.GeneratedPasswordForUser(_id);
    }

    /// <summary>
    /// method to verify if the password is still valid for the user
    /// </summary>
    /// <param name="password">password introduced</param>
    /// <returns> boolean value for the validity </returns>
    public bool IsPasswordValid(string password)
    {
        return PasswordGenerator.IsPasswordValid(password, _id);
    }
}