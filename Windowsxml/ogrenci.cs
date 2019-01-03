using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windowsxml
{
   public class ogrenci
    {
        private Guid id;

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }
        private string soyadi;

        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }
        private DateTime dogumtarihi;

        public DateTime Dogumtarihi
        {
            get { return dogumtarihi; }
            set { dogumtarihi = value; }

        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
      
        private cinsiyet cins;

        public cinsiyet Cins
        {
            get { return cins; }
            set { cins = value; }
        }

    }
        public enum cinsiyet {
        /// <summary>
        /// /
        /// </summary>
    kadın=1,
    erkek=2,
    LGBT=3
    }
}
