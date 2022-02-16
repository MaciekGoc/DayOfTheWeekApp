using DayOfTheWeekApp.Core;
using System;

namespace DayOfTheWeekApp
{
    public class DayGuesser
    {
        public DayCalculator Calculator { get; set; }

        public DateTimeOffset UserDateOfBirth { get; set; }
        public DayOfTheWeek UserDayOfTheWeek { get; set; }

        public void IntroduceTheApplication()
        {
            Console.WriteLine("Witaj, jestem botem, który potrafi wyliczać dzień tygodnia na podstawie Twojej daty urodzenia.");

            Calculator = new DayCalculator();
        }
        

        public void AskUserForTheirDateOfBirth()
        {
            Console.WriteLine("Podaj proszę swoją datę urodzenia:");

            var userDate = Console.ReadLine();

            var succeded = DateTimeOffset.TryParse(userDate, out var date);

            if (succeded)
            {
                UserDateOfBirth = date;
                return;
            }

            Console.WriteLine("Format daty nieprawidłowy. Proszę go podać w dd/mm/yyyy");
            AskUserForTheirDateOfBirth();
        }

        public void CalculateDayOfTheWeek()
        {
            if (UserDateOfBirth == null)
            {
                Console.WriteLine("Próbowano obliczyć dzień tygodnia bez podania daty urodzenia");
                return;
            }

            UserDayOfTheWeek = Calculator.CalculateDayOfTheWeek(UserDateOfBirth);
        }

        public void PrintDayOfTheWeek()
        {
            Console.WriteLine("Obliczony dzień tygodnia to: " + UserDayOfTheWeek.ToPolishString());
            Console.WriteLine("Dziękuję za kooperację!");
        }
    }
}
