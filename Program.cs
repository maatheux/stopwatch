using System;
using System.Threading;

namespace Stopwatch
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }


    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("S - Segundos / M - Minutos / E - Sair ");
      Console.WriteLine("Ex: 2s -> 2 segundos / 4m -> 4 minutos");
      Console.WriteLine("Quanto tempo deseja contar?");
      
      string? time = Console.ReadLine()?.ToLower();

      if (time == "e") System.Environment.Exit(0);

      int seconds = getSeconds(time); 

      Start(seconds);
      
    }

    static void Start(int time)
    {
      int currentTime = 0;
      int sec = 0;
      int min = 0;

      while (currentTime < time)
      {
        while (sec < 60 )
        {
          if (currentTime > time) break;

          Console.Clear();
        
          Console.WriteLine($"{(min < 10 ? '0' : "")}{min}:{(sec < 10 ? '0' : "")}{sec}");
          
          
          currentTime++;
          sec++;
          /* Console.WriteLine(currentTime); */
          Thread.Sleep(1000); // A função Sleep indica quanto tempo em segundos nossa aplicacao ira dormir

        }

        if (currentTime > time) break;

        min++;
        sec = 0;

        Console.Clear();
        Console.WriteLine($"{(min < 10 ? '0' : "")}{min}:{(sec < 10 ? '0' : "")}{sec}");

      }

      /* Console.Clear(); */
      Console.WriteLine("Stopwatch finalizado!");
      Thread.Sleep(2500);

    }

    static int getSeconds(string timeReceived = "0s")
    {
      string lastChar = (timeReceived[timeReceived.Length-1]).ToString();

      if (lastChar != "m" && lastChar != "s")
      {
        Console.WriteLine("Digite um valor válido!");
        Thread.Sleep(3000);
        Menu();
      }

      if (lastChar == "m") return int.Parse(timeReceived.Substring(0, timeReceived.Length-1)) * 60;

      return int.Parse(timeReceived.Substring(0, timeReceived.Length-1));

    }

  }
}
