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
				/** /
				Console.Error.WriteLine("---------------------------------");
				Console.Error.WriteLine($"Ezt kell beilleszteni: {elem}");
				Console.Error.WriteLine($"Hozzáadás előtt: [{this} ]");
				/**/
				int hely_indexe = Helye(elem);
				/** /
				Console.Error.WriteLine($"Az elem helye: {hely_indexe}");
				/**/
				lista.Insert(hely_indexe, elem);
				/** /
				Console.Error.WriteLine($"Hozzáadás után: [{this} ]");
				Console.Error.WriteLine("---------------------------------");
				/**/
				Count++; // ezt felejtettük el a múltkor!
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

			public void Remove(int elem)
			{
				int hely = Helye(elem);
				if (lista.Count<=hely)
					return;

				if (lista[hely]==elem)
				{
					lista.RemoveAt(hely);
					Count--;
				}
			}

			public RendezettHalmaz Unio(RendezettHalmaz that)
			{
				RendezettHalmaz result = new RendezettHalmaz();

				int i = 0;
				int j = 0;

				while (i < this.Count && j < that.Count)
				{
					if (this.lista[i] < that.lista[j])
					{
						result.lista.Add(this.lista[i]);
						i++;
					}
					else if (this.lista[i] > that.lista[j])
					{
						result.lista.Add(that.lista[j]);
						j++;
					}
					else
					{
						result.lista.Add(this.lista[i]);
						result.lista.Add(that.lista[j]);
						i++;
						j++;
					}
					//Console.WriteLine(result);
				}

				//Console.WriteLine("kifogyott az valamelyik");
				while (i < this.lista.Count)
				{
					result.lista.Add(this.lista[i]);
					i++;
					//Console.WriteLine(result);
				}
				//Console.WriteLine("kifogyott az első");

				while (j < that.lista.Count)
				{
					result.lista.Add(that.lista[j]);
					j++;
					//Console.WriteLine(result);
				}
				//Console.WriteLine("kifogyott a második");
				return result;
			}

			/*
			public static RendezettHalmaz Unio(RendezettHalmaz egyik, RendezettHalmaz másik)
			{
				return egyik.Unio(másik);
			}
			*/
			public static RendezettHalmaz Unio(RendezettHalmaz egyik, RendezettHalmaz másik) => egyik.Unio(másik);

			public static RendezettHalmaz operator +(RendezettHalmaz egyik, RendezettHalmaz másik) => egyik.Unio(másik);

		}

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 6, 9 , 40, 41, 42, 43, 43, 43, 43, 43, 43, 43, 54};
			List<int> lista2 = new List<int> { 3, -2, 5, 9, -3, 2, -1, 4, 10, 15 };
			RendezettHalmaz rendeshalmaz = new RendezettHalmaz();
			RendezettHalmaz rendeshalmaz2 = new RendezettHalmaz();

			//			Random rnd = new Random();
			for (int i = 0; i < lista.Count; i++)
			{
				rendeshalmaz.Add(lista[i]);
			}

			for (int i = 0; i < lista2.Count; i++)
			{
				rendeshalmaz2.Add(lista2[i]);
			}

			Console.WriteLine(rendeshalmaz);
			Console.WriteLine(rendeshalmaz2);

			// Opciók arra, hogy hogyan lehetne egy uniót használni:
			// 1. 
			Console.WriteLine(rendeshalmaz.Unio(rendeshalmaz2));
			// 2. 
			Console.WriteLine(RendezettHalmaz.Unio(rendeshalmaz, rendeshalmaz2));
			// 3. 
			Console.WriteLine(rendeshalmaz + rendeshalmaz2);

			Console.ReadKey();
		}

	}
}
