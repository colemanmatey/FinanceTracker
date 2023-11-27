using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
        // Get list of all accounts from file
        accounts = LoadAccounts();

        // Add new account to the list
        accounts.Add(account);

        // Save the new list back to the file
        SaveAccounts(accounts);

    }
    public void RemoveAccount(Account account)
    {
        // Get list of all accounts from file
        accounts = LoadAccounts();

        // Remove new account from the list
        accounts.Remove(account);

        // Save the new list back to the file
        SaveAccounts(accounts);

    }

    private void SaveAccounts(List<Account> accounts)
    {
        // Serialize accounts to JSON and save to file
        string json = JsonSerializer.Serialize(accounts);
        File.WriteAllText(FileName, json);
    }

    private List<Account> LoadAccounts()
    {
        // Deserialize accounts from JSON file
        // if (File.Exists(FileName)){

        // }
        return new List<Account>();
    }
}