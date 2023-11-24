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

    public void SaveAccounts()
    {
        // Serialize accounts to JSON and save to file
        string jsonData = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, jsonData);
    }

    public List<Account> LoadAccounts()
    {
        // Deserialize accounts from JSON file
        if (File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);
            List<Account>? data = JsonSerializer.Deserialize<List<Account>>(json);
            return data; // To-Do Resolve Possible null reference return 
        }
        else
        {
            return new List<Account>();
        }
    }
}