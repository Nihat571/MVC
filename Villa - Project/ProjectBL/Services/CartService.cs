using ProjectDAL.Context;
using ProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBL.Services
{
    public class CartService
    {
        private readonly VillaCartDB _villaDB;
        public CartService()
        {
            _villaDB = new VillaCartDB();
        }

        #region Create

        public void AddVilla(VillaCart newVilla)
        {
            _villaDB.villaCarts.Add(newVilla);
            _villaDB.SaveChanges();
        }


        #endregion


        #region Read

        public List<VillaCart> ReadCart()
        {
            return _villaDB.villaCarts.ToList();
        }


        public VillaCart GetCartById(int id)
        {
            VillaCart? foundedCart = _villaDB.villaCarts.Find(id);
            if(foundedCart is not null)
            {
                return foundedCart;
            }
            else
            {
                throw new Exception("data not found");
            }
        }

        #endregion

        #region Update

        public void UpdateVilla(int id,VillaCart newVilla) 
        {
        VillaCart? clickedVilla = GetCartById(id);
            
                clickedVilla.Parking = newVilla.Parking;
                clickedVilla.Area = newVilla.Area;
                clickedVilla.Bedrooms = newVilla.Bedrooms;
                clickedVilla.Bathrooms = newVilla.Bathrooms;
                clickedVilla.Floor = newVilla.Floor;
                clickedVilla.ImgUrl = newVilla.ImgUrl;
                clickedVilla.Type = newVilla.Type;
                clickedVilla.Name = newVilla.Name;
                clickedVilla.Price = newVilla.Price;
            _villaDB.SaveChanges();
            
        }

        #endregion

        #region Delete

        public void DeleteFilla(int id)
        {
            VillaCart clickedVilla = GetCartById(id);
            _villaDB.villaCarts.Remove(clickedVilla);
            _villaDB.SaveChanges();                     
        }

        #endregion

    }
}
