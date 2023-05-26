using _001JIMCV.Models.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace _001JIMCV.Models
{
    public class Dal : IDisposable
    {
        // Attribut
        private BDDContext _bddcontext;

        //Constructeur
        public Dal()
        {
            _bddcontext = new BDDContext();
        }        


        // méthode pour libérer les ressources utilisées par l'objet _bddcontext
        public void Dispose()
        {
            _bddcontext.Dispose();
        }


    }
}
