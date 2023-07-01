using System;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge.Implementation;
using NUnit.Framework;

namespace CodeChallenge.Tests;

/// <summary>
/// class for testing if the password generator works 
/// </summary>
[TestFixture]
public class PasswordGeneratorTest
{
    private User _userTest1;
    private User _userTest2;
    private User _userTest3;

    /// <summary>
    /// preparing data for testing 3 users to see if their data is creating and the hashes are different
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _userTest1 = new User(10);
        _userTest2 = new User(15);
        _userTest3 = new User(20);
    }

    /// <summary>
    /// test where we will check that the 3 passwords we re created and they are different one from another
    /// </summary>
    [Test]
    public void PasswordGenerationTest()
    {
        string password1 = _userTest1.GeneratePassword();
        Assert.NotNull(password1);
        Assert.AreEqual(password1.Length, 10);

        string password2 = _userTest2.GeneratePassword();
        Assert.NotNull(password2);
        Assert.AreEqual(password2.Length, 10);

        string password3 = _userTest3.GeneratePassword();
        Assert.NotNull(password3);
        Assert.AreEqual(password3.Length, 10);

        Assert.AreNotEqual(password1, password2);
        Assert.AreNotEqual(password1, password3);
        Assert.AreNotEqual(password2, password3);
    }

    /// <summary>
    /// test where we will check that the 3 users can generate a valid password and after 30 seconds = 30000 milliseconds
    /// the passwords become invalid
    /// </summary>
    [Test]
    public void PasswordValidityTest()
    {
        string password1 = _userTest1.GeneratePassword();
        Assert.That(_userTest1.IsPasswordValid(password1));
        Thread.Sleep(30001);
        Assert.That(!_userTest1.IsPasswordValid(password1));

        string password2 = _userTest2.GeneratePassword();
        Assert.That(_userTest2.IsPasswordValid(password2));
        Thread.Sleep(30001);
        Assert.That(!_userTest2.IsPasswordValid(password2));

        string password3 = _userTest3.GeneratePassword();
        Assert.That(_userTest3.IsPasswordValid(password3));
        Thread.Sleep(30001);
        Assert.That(!_userTest3.IsPasswordValid(password3));
    }
}