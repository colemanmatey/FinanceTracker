using System;
using System.Collections.Generic;

namespace FinanceTracker;

public class Account
{
    private static HashSet<int> usedAccountIDs = new HashSet<int>();
    private static HashSet<string> usedAccountNames = new HashSet<string>();

    public int AccountID { get; private set; }

    private string _accountName = string.Empty;
    public string AccountName
    {
        get { return _accountName; }
        set
        {
            if (!usedAccountNames.Contains(value))
            {
                // If the accountID is unique, set it and add to the set of used IDs
                _accountName = value;
                usedAccountNames.Add(_accountName);
            }
            else
            {
                // Handle the case where the proposed accountID is not unique
                throw new InvalidOperationException($"An account with the name {_accountName} already exists!");
            }
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
    private void InitializeAccount()
    {
        AssignAccountNumber();
        SetNormalBalance();
    }

    private void AssignAccountNumber()
    {
        int number = GenerateRandomNumber();
        AccountID = number;

        // If the generated number is not used, assign the number to account else generate another number
        if (!usedAccountIDs.Contains(number))
        {
            AccountID = number;
        }
        else
        {
            AssignAccountNumber();
        }
    }

    private int GenerateRandomNumber()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(1, 100);
        int categoryCode = (int)AccountType;
        if (categoryCode == 0)
        {
            categoryCode = 9;
        }
        return (categoryCode * 100) + randomNumber;
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
}

public enum AccountType
{
    Unassigned,
    Asset,
    Liability,
    Equity,
    Revenue,
    Expenditure,
}

public enum DrCr
{
    Debit,
    Credit,
}
