using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GameRepo:IGame
    {
        public string Key { get; set; }
		public string search { get; set; }

		public GameRepo()
        {
			DateTime localDate = DateTime.Now;
			int day = localDate.Day;
			int hour = localDate.Hour;

			if (day < 10 && hour < 10)
			{
				Key = "0" + day.ToString() + "0" + hour.ToString();
			}
			else if (day < 10)
			{
				Key = "0" + day.ToString() + hour.ToString();

			}
			else if (hour < 10)
			{
				Key = day.ToString() + "0" + hour.ToString();
			}
			else
			{
				Key = day.ToString() + hour.ToString();
			}


		}

		public string Compare(string search)
        {
			int bull = 0;
			int cow = 0;
			for (int i = 0; i < 4; i++)
			{
				if (search[i] == Key[i])
				{
					bull += 1;
				}
				else
				{
					for (int j = 0; j < 4; j++)
					{
						if (search[i] == Key[j])
							cow++;
					}
				}


			}
			if (bull == 4)
			{
				return "You Won";
			}
			else
			{
				return $"Your Score is {bull} bulls and {cow} cows.";
			}
		}
    }
}
