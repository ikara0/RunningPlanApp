using System.Globalization;


var flag = true;

while (flag)
{
    Console.WriteLine("---------------Koşu Mesafesi Hesaplama Hesaplama Uygulamasına Hoşgeldiniz!---------------");
    Console.WriteLine("=========================================================================================");

    var stepDistance = GetInputValue("Lütfen Adım Uzunluğunuzu Giriniz:");

    var stepFreq = GetInputValue("Lütfen Adım Sıklığınızı Giriniz:");

    var runningHour = GetRunningTime("Lütfen Koşu Süresi Saati Giriniz:");

    var runningMinute = GetRunningTime("Lütfen Koşu Süresi Dakikasını Giriniz:");

    var result = Calculate.CalculateRunning(stepDistance, stepFreq, runningHour, runningMinute);

    Console.WriteLine($"\n\nKoşu Planı:\nAdım Mesafesi: {stepDistance}\nKoşulan Süre: {runningHour + runningMinute}\nBir Dakikada Atılan Adım Sayısı : {stepFreq}\nToplam Adım Sayısı : {stepFreq * (runningHour + runningMinute)}\nToplam Mesafe : {result} metre");

    flag = WantToAgain();
}



bool WantToAgain()
{
    while (true)
    {
        Console.Write("Tekrar Denemek İster Misiniz ? (Evet(e)/Hayır(h))");
        var answer = Console.ReadLine().ToLower();
        if (answer == "e" || answer == "evet")
        {
            Console.Clear();
            return true;
        }
        else if (answer == "h" || answer == "hayır")
        {
            Console.WriteLine("İyi Günler Dileriz :)");
            return false;
        }
        else
        {
            Console.WriteLine("Yanlış Bir Giriş Yaptınız.Tekrar Deneyiniz.");
        }

    }
}

int GetRunningTime(string message)
{
    var flag = true;

    while (flag)
    {
        Console.Write(message);
        int value = 0;
        var input = int.TryParse(Console.ReadLine(), out value);
        if (input)
        {
            if (!(value < 0))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Lütfen Doğru Bir Giriş Yapınız.");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Yanlış Bir Giriş Yaptınız. Lütfen Tekrar Deneyiniz:");
            continue;
        }

    }

    return 0;
}

double GetInputValue(string message)
{
    var flag = true;

    while (flag)
    {
        try
        {
            Console.Write(message);
            double value = 0;
            var input = Console.ReadLine();

            if (input.Contains('.'))
            {
                value = Double.Parse(input, new CultureInfo("en-US"));
            }
            else if (input.Contains(','))
            {
                value = Double.Parse(input, new CultureInfo("tr-TR"));
            }
            else
            {
                value = Double.Parse(input, CultureInfo.CurrentCulture);
            }
            if (value <= 0)
            {
                Console.WriteLine("Girilen Değer 0'dan Büyük Olmalıdır. Lütfen Tekrar Deneyiniz.");
                continue;
            }
            return value;
        }
        catch (Exception)
        {
            Console.WriteLine("Girmiş Olduğunuz Değer Yanlıştır. Lütfen Tekrar Deneyiniz.");
            continue;
        }
    }
    return default(double);
}

public static class Calculate
{
   public static double CalculateRunning(double stepDistance, double stepFreq, double runningHour, double runningMinute)
    {
        var result = stepDistance * stepFreq * ((runningHour * 60) + runningMinute) * 0.01;
        return result;
    }
}

