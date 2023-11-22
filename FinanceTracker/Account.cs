using System;

namespace FinanceTracker;
public class Account
{
    #region Properties
    public int AccountID { get; set; }
    public string AccountName { get; set; }

    private Classification _accountType;
    public Classification AccountType
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
        AccountType = Classification.Unassigned;
        SetNormalBalance();
    }

    #endregion

    #region Methods
    private void SetNormalBalance()
    {
        switch (AccountType)
        {
            case Classification.Asset:
            case Classification.Expenditure:
                NormalBalance = DrCr.Debit;
                break;
            case Classification.Liability:
            case Classification.Equity:
            case Classification.Revenue:
                NormalBalance = DrCr.Credit;
                break;
            default:
                NormalBalance = DrCr.Credit;
                break;
        }
    }
    #endregion

}

public enum Classification
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
