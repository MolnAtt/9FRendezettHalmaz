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
			public int Count;
			private List<int> lista;
		}

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 6, 9 };

			RendezettHalmaz rendeshalmaz = new RendezettHalmaz();
			// nem szeretnénk ilyet megengedni
			Console.WriteLine(rendeshalmaz.Count);
			rendeshalmaz.lista.Add(2);
			rendeshalmaz.Add();



		}
	}
}
