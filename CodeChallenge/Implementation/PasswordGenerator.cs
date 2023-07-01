using System.Security.Cryptography;
using System.Text;
using OtpNet;

namespace CodeChallenge.Implementation;

using System;

/// <summary>
/// we are going to use the OtpNet library in order to generate the password and be consistent with the availability of the password.
/// The given parameters will give set up the size of the password and the validity time
/// </summary>
public static class PasswordGenerator
{
    private const int PasswordDigits = 10;
    private const int TimeStepSeconds = 30;
    private const string PasswordCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    /// <summary>
    /// we will create a static class that will generate password based the user ID.
    /// This will allow for good testing environments by splitting the password generation from the basic user functions
    /// </summary>
    /// <param name="id">
    /// id of the user
    /// </param>
    /// <returns>
    /// password string for the given user
    /// </returns>
    public static string GeneratedPasswordForUser(int id)
    {
        byte[] secretKey = GetSecretKey(id);
        Totp totp = new Totp(secretKey, step: TimeStepSeconds, totpSize: PasswordDigits);
        string totpValue = totp.ComputeTotp().ToString();
        return totpValue;
    }

    /// <summary>
    /// the method will give us the key to the user and generate it,
    /// also the optNet library takes into account the current time and date we only specify the validity time 
    /// </summary>
    /// <param name="id">
    /// id of the current user
    /// </param>
    /// <returns>
    /// the secret key as a string 
    /// </returns>
    public static byte[] GetSecretKey(int id)
    {
        //we can retrieve the secret key by the user id given
        string key = "MySecretKey_" + id;
        return Encoding.UTF8.GetBytes(key);
    }

    /// <summary>
    /// method in order to check the validity of the password generated the size and also,
    /// the time stamp
    /// </summary>
    /// <param name="password">
    /// password written by the user in order to authenticate
    /// </param>
    /// <param name="id">
    /// id of the user 
    /// </param>
    /// <returns>
    /// boolean value for the validity of the password
    /// </returns>
    public static bool IsPasswordValid(string password, int id)
    {
        byte[] secretKey = GetSecretKey(id);
        Totp totp = new Totp(secretKey, step: TimeStepSeconds, totpSize: PasswordDigits);
        return totp.VerifyTotp(password, out _);
    }
}