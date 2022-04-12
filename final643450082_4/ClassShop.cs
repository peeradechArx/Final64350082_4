using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final643450082_4
{
    internal class ClassShop
    {
        private string _name;
        private string _amount;
        private string _price;
    

        public ClassShop(string name, string amount, string price, string v)
        {
           
            this._name = name;
            this._amount = amount;
            this._price = price;
        }
      
        public string getName()
        {
            return _name;
        }
        public string getAmount()
        {
            return _amount;
        }
        public string getPrice()
        {
            return _price;
        }
    }
}

