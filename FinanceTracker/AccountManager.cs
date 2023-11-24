using System.Collections.Generic;

namespace FinanceTracker;

public class AccountManager
{
    private List<Account> accounts;
    private const string FileName = "accounts.json";


    public AccountManager()
    {
        // Create a list of accounts
        accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        // Add account to the list
        accounts.Add(account);
    }
    public void RemoveAccount(Account account)
    {
        // Add account to the list
        accounts.Remove(account);
    }

    public List<Account> GetAllAccounts()
    {
        // Retrieve the list of all accounts
        return accounts;
    }

    public void SerializeToJson(string filePath)
    {
        // Serialize accounts to JSON and save to file
        // To-Do
    }

    public void DeserializeFromJson(string filePath)
    {
        // Deserialize accounts from JSON file
        // To-Do
    }
}