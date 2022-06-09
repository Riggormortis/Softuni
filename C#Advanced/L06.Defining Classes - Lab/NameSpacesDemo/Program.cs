using System;
using Shop;
using CarManufacturer;
namespace NameSpacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop.Cart cart = new Shop.Cart();

            Engine Car = new Engine(5, 5);


            Buyer buyer = new Buyer(); //<- ako polzvame gore using

            Marketing.Ad ad = new Marketing.Ad(); //<- bez using
        }
    }
}
