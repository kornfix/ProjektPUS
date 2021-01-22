using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class SingletonBaza
    {
        private static SingletonBaza _instance;
        private BazaDataContext _bazaDC;

        public BazaDataContext BazaDC
        {
            get
            {
                return _bazaDC;
            }
        }
        protected SingletonBaza()
        {
            _bazaDC = new BazaDataContext();
        }
        public static SingletonBaza Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonBaza();
                }
                return _instance;
            }
        }
    }
}
