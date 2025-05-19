using New_Project_N_Tier.DAL.Contexts;
using New_Project_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Project_N_Tier.BL.Services
{
    public class NTFCartService
    {
        private readonly NFTContextDB _nFTDB;

        public NTFCartService()
        {
            _nFTDB = new NFTContextDB();
        }

        #region CREATE

        public void AddCart(NTFCart newCart)
        {
            _nFTDB.NFTCart.Add(newCart);
            _nFTDB.SaveChanges();
        }
        #endregion
        #region UPDATE

        public void UpdateCart(int id,NTFCart newNTFCart)
        {
            NTFCart? clickedCart = ReadCartById(id);
            
            clickedCart.Name = newNTFCart.Name;
            clickedCart.maxNumber = newNTFCart.maxNumber;
            clickedCart.minNumber = newNTFCart.minNumber;
            clickedCart.ImgUrl = newNTFCart.ImgUrl;
            _nFTDB.SaveChanges();

        }
        #endregion
        #region READ

        public List<NTFCart> ReadCart()
        {
            return _nFTDB.NFTCart.ToList();
        }

        public NTFCart ReadCartById(int id)
        {
            NTFCart? foundedCart = _nFTDB.NFTCart.Find(id);
            if (foundedCart is not null)
            {
                return foundedCart;
            }
            else
            {
                throw new Exception("data not found");
            }
        }


        #endregion
        #region DELETE

        public void DeleteCart(int id)
        {
            NTFCart? clickedCart = ReadCartById(id);
            _nFTDB.NFTCart.Remove(clickedCart);
            _nFTDB.SaveChanges();
        }


        #endregion
    }
}
