using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLS_CLI {
    public class AutoAdatok {

        public DateTime Datum { get; private set; }
        public string SoforNev { get; private set; }
        public int NapiKilometer { get; private set; }
        public int KezbesitettCsomagokSzama { get; private set; }
        public int NapiFogyasztas { get; private set; }

        public AutoAdatok(string sor) {
            string[] temp = sor.Split(';');
            Datum = DateTime.Parse(temp[0]);
            SoforNev = temp[1];
            NapiKilometer = int.Parse(temp[2]);
            KezbesitettCsomagokSzama = int.Parse(temp[3]);
            NapiFogyasztas = int.Parse(temp[4]);
        }
        public void Modosito(AutoAdatok mireModositjuk)
        {
            Datum = mireModositjuk.Datum;
            SoforNev = mireModositjuk.SoforNev;
            NapiKilometer = mireModositjuk.NapiKilometer;
            KezbesitettCsomagokSzama = mireModositjuk.KezbesitettCsomagokSzama;
            NapiFogyasztas = mireModositjuk.NapiFogyasztas;
        }
    }
}