using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9FRendezettHalmaz
{
	class Program
	{

		// első saját fejlesztésű halmazfogalmunk!
		// mindig rend lesz benne!

		class RendezettHalmaz
		{
			//tulajdonságok 
			public int Count;  // public = bárki elérheti
			private List<int> lista; // private = kívülről senki nem fér hozzá

			public RendezettHalmaz()
			{
				Count = 0;
				lista = new List<int>();
			}

			private int Helye(int elem)
			{
				if (Count==0)
				{
					return 0;
				}

				int e = 0;
				int v = Count - 1;
				int k;

				do
				{
					k = (e + v) / 2;

					if (lista[k] < elem)
					{
						e = k + 1;
					} 
					else if (lista[k] > elem)
					{
						v = k - 1;
					}
				} while (e <= v && lista[k]!=elem);
				return lista[k]==elem ? k : e;
			}

			public void Add(int elem)
			{
				// az elem helyét meg kell találni! mert oda kell berakni!
				int hely_indexe = Helye(elem);
				lista.Insert(hely_indexe, elem);
			}

			public override string ToString()
			{
				string s = "";
				foreach (int item in lista)
				{
					s += " " + item.ToString();
				}
				return s;
			}

		}

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 6, 9 };

			RendezettHalmaz rendeshalmaz = new RendezettHalmaz();
			// nem szeretnénk ilyet megengedni
			Console.WriteLine(rendeshalmaz.Count);

			Console.WriteLine(rendeshalmaz);

			rendeshalmaz.Add(6);
			Console.WriteLine(rendeshalmaz);
			rendeshalmaz.Add(2);
			Console.WriteLine(rendeshalmaz);
			rendeshalmaz.Add(7);
			Console.WriteLine(rendeshalmaz);
			rendeshalmaz.Add(1);
			Console.WriteLine(rendeshalmaz);
			rendeshalmaz.Add(9);
			Console.WriteLine(rendeshalmaz);

			Console.ReadKey();

			/* Ezt később ki fogjuk törölni!*/


		}

	}
}
