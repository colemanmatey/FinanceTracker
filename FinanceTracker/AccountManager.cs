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
        // Add new account to the list
        accounts.Add(account);
    }
    public void RemoveAccount(Account account)
    {
        // Remove new account from the list
        accounts.Remove(account);
    }

    public void SaveAccounts()
    {
        // Serialize accounts to JSON and save to file
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(FileName, json);
    }

    public List<Account> LoadAccounts()
    {
        // Deserialize accounts from JSON file
        if (File.Exists(FileName))
        {
            string data = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Account>>(data) ?? new List<Account>();
        }
        else
        {
            return new List<Account>();
        }
    }
}
