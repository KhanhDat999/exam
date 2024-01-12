using System;

class Program
{
    static void Main()
    {
        BankAccount bankAccount = new BankAccount();

        Console.WriteLine("Ngân hàng VCB - Đăng nhập");
        Console.Write("Nhập tên đăng nhập: ");
        string username = Console.ReadLine();
        Console.Write("Nhập mật khẩu: ");
        string password = Console.ReadLine();

        if (bankAccount.Login(username, password))
        {
            Console.WriteLine($"Đăng nhập thành công, Chào mừng {username}!");

            while (true)
            {
                Console.WriteLine("\nChọn chức năng:");
                Console.WriteLine("1. Rút tiền");
                Console.WriteLine("2. Nạp tiền");
                Console.WriteLine("3. Kiểm tra tài khoản");
                Console.WriteLine("4. Đăng xuất");
                Console.Write("Chọn: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Chọn số tiền cần rút:");
                        Console.WriteLine("1. 500k");
                        Console.WriteLine("2. 1000k");
                        Console.WriteLine("3. 1500k");
                        Console.Write("Chọn: ");
                        int withdrawChoice = Convert.ToInt32(Console.ReadLine());

                        int withdrawAmount = 0;
                        switch (withdrawChoice)
                        {
                            case 1:
                                withdrawAmount = 500;
                                break;
                            case 2:
                                withdrawAmount = 1000;
                                break;
                            case 3:
                                withdrawAmount = 1500;
                                break;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ");
                                continue;
                        }

                        if (bankAccount.Withdraw(withdrawAmount))
                        {
                            Console.WriteLine($"Rút {withdrawAmount}k thành công.");
                        }
                        else
                        {
                            Console.WriteLine("Không đủ tiền hoặc số tiền rút không hợp lệ.");
                        }
                        break;

                    case 2:
                        Console.Write("Nhập số tiền cần nạp: ");
                        int depositAmount = Convert.ToInt32(Console.ReadLine());
                        bankAccount.Deposit(depositAmount);
                        Console.WriteLine($"Nạp {depositAmount}k thành công.");
                        break;

                    case 3:
                        bankAccount.CheckBalance();
                        break;

                    case 4:
                        bankAccount.Logout();
                        Console.WriteLine("Đã đăng xuất.");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Đăng nhập không thành công. Sai tên đăng nhập hoặc mật khẩu.");
        }
    }
}

class BankAccount
{
    private string username = "admin";
    private string password = "password";
    private double balance = 10000; 

    public bool Login(string inputUsername, string inputPassword)
    {
        return (username == inputUsername && password == inputPassword);
    }

    public void Logout()
    {
       
    }

    public bool Withdraw(int amount)
    {
        double minimumBalance = 500; 
        double transactionFeeRate = 0.067; 

        if (amount % 50 == 0 && amount <= (balance - minimumBalance))
        {
            double transactionFee = amount * transactionFeeRate;
            balance -= (amount + transactionFee);
            Console.WriteLine($"Phí giao dịch: {transactionFee}k");
            return true;
        }
        return false;
    }

    public void Deposit(int amount)
    {
        double transactionFeeRate = 0; 
        double transactionFee = amount * transactionFeeRate;
        balance += (amount - transactionFee);
        Console.WriteLine($"Phí giao dịch: {transactionFee}k");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Số dư hiện tại: {balance}k");
    }
}
