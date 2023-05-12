using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpelLista
{
	class MusikData
	{
		// Variabler till låtarnas data
		string titel = "";
		string genre = "";
		string artist = "";
		double speltid = 0.0;
		double totalspeltid = 0.0;

		// Redigerar datan för vald låt
		public void redigeraTitel(string nyTitel)
		{
			titel = nyTitel;
		}
		public void redigeraGenre(string nyGenre)
		{
			genre = nyGenre;
		}
		public void redigeraArtist(string nyArtist)
		{
			artist = nyArtist;
		}

		public void redigeraSpeltid(int nySpeltid)
		{
			speltid = nySpeltid;
		}

		// Funktion för att visa låtarna 
		public void visaLåtar()
        {
			Console.WriteLine("Titel: {0}   Artist: {1}   Genre: {2}   Speltid: {3}min", titel, artist, genre, speltid);
		}

		public MusikData(string titel, string genre, string artist, double speltid)
        {
			this.titel = titel;
			this.genre = genre;
			this.artist = artist;
			this.speltid = speltid;

        }
	}
}

