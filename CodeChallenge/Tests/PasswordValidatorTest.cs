using System.Threading.Tasks;
using CodeChallenge.Implementation;
using NUnit.Framework;

namespace CodeChallenge.Tests;
/// <summary>
/// we create a test class for testing the validity of the password
/// </summary>
[TestFixture]
public class PasswordValidatorTest
{
    private User _testUser1;
    private User _testUser2;
    private User _testUser3;
    /// <summary>
    /// creating the set up data for the following tests
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _testUser1 = new User(10);
        _testUser2 = new User(15);
        _testUser3 = new User(20);
    }
    /// <summary>
    /// we generate passwords for the users then we make them wait for 30 seconds = 30000 milliseconds
    /// thus check if their passwords are no longer valid
    /// </summary>
    [Test]
    public void ValidatorTest()
    {
        string password1 = _testUser1.GeneratePassword();
        Assert.That(_testUser1.IsPasswordValid(password1));
        Task.Delay(30000);
        Assert.That(!_testUser1.IsPasswordValid(password1));
        
        string password2 = _testUser2.GeneratePassword();
        Assert.That(_testUser2.IsPasswordValid(password2));
        Task.Delay(30000);
        Assert.That(!_testUser2.IsPasswordValid(password2));

        string password3 = _testUser3.GeneratePassword();
        Assert.That(_testUser3.IsPasswordValid(password3));
        Task.Delay(30000);
        Assert.That(!_testUser3.IsPasswordValid(password3));
    }
}