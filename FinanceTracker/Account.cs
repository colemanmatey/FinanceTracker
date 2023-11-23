using System;
using System.Collections.Generic;

namespace FinanceTracker;
public class Account
{
    #region Static members
    public static List<Account> ListOfAccounts = new List<Account>();
    #endregion

    #region Properties
    public int AccountID { get; private set; }

    private string _accountName = string.Empty;
    public string AccountName
    {
        get { return _accountName; }
        set
        {
            List<string> accountNames = GetAllAccountNames();
            if (accountNames.Contains(value))
            {
                throw new InvalidOperationException($"An account '{value}' already exists!");
            }
            _accountName = value;
        }
    }

    private AccountType _accountType;
    public AccountType AccountType
    {
        get { return _accountType; }
        set
        {
            _accountType = value;
            SetNormalBalance();
        }
    }

    public DrCr NormalBalance { get; private set; }
    #endregion

    #region Contructors
    public Account()
    {
        AccountType = AccountType.Unassigned;
        InitializeAccount();
    }

    public Account(string name, AccountType accountType)
    {
        AccountName = name;
        AccountType = accountType;
        InitializeAccount();
    }
    #endregion

    #region Methods
    // Instance methods
    private void InitializeAccount()
    {
        AssignAccountNumber();
        SetNormalBalance();
        ListOfAccounts.Add(this);
    }

    private void AssignAccountNumber()
    {
        List<int> accountNumbers = GetAllAccountNumbers();

        int number = GenerateRandomNumber();
        AccountID = number;
        if (accountNumbers.Contains(number))
        {
            AssignAccountNumber();
        }
        else
        {
            AccountID = number;
        }
    }

    private int GenerateRandomNumber()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(1, 100);
        int categoryCode = (int)AccountType;
        return categoryCode + randomNumber;
    }

    private void SetNormalBalance()
    {
        switch (AccountType)
        {
            case AccountType.Asset:
            case AccountType.Expenditure:
                NormalBalance = DrCr.Debit;
                break;
            case AccountType.Liability:
            case AccountType.Equity:
            case AccountType.Revenue:
                NormalBalance = DrCr.Credit;
                break;
            default:
                NormalBalance = DrCr.Credit;
                break;
        }
    }

    // Static methods
    private static List<string> GetAllAccountNames()
    {
        List<string> accountNames = new List<string>();
        foreach (var account in ListOfAccounts)
        {
            accountNames.Add(account.AccountName);
        }
        return accountNames;
    }

    private static List<int> GetAllAccountNumbers()
    {
        List<int> accountNumbers = new List<int>();
        foreach (var account in ListOfAccounts)
        {
            accountNumbers.Add(account.AccountID);
        }
        return accountNumbers;
    }
    #endregion
}

public enum AccountType
{
    Unassigned = 900,
    Asset = 100,
    Liability = 200,
    Equity = 300,
    Revenue = 400,
    Expenditure = 500,
}

public enum DrCr
{
    Debit,
    Credit,
}
