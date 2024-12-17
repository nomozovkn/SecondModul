namespace _2._5_dars;

internal class BankAccaunt
{
    private string _accountNumber;

    public string AccountNumber
    {
        get { return _accountNumber; }

    }
    private double _balance;

    public double Double
    {
        get { return _balance; }

    }
    public void Deposite(double amount)
    {
        _balance += amount;
    }






}
