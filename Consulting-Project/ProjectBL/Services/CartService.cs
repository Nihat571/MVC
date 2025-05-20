using ProjectDAL.Contexts;
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
        private readonly CartDbContext _cartDB;
        public CartService(CartDbContext context)
        {
            _cartDB = context;
        }

        #region Create

        public void AddTeamMember(TeamCart newMember)
        {
            _cartDB.carts.Add(newMember);
            _cartDB.SaveChanges();
        }

        #endregion

        #region Read

        public List<TeamCart> ReadMembers()
        {
            return _cartDB.carts.ToList();
        }

        public TeamCart GetCartById(int id)
        {
            TeamCart? clickedCart = _cartDB.carts.Find(id);
            if (clickedCart is not null)
            {
                return clickedCart;
            }
            else
            {
                throw new Exception("data not found");
            }
        }

        #endregion

        #region UPDATE

        public void UpdateMembers(int id,TeamCart newMember)
        {
            TeamCart clickedCart = GetCartById(id);
            clickedCart.Name = newMember.Name;
            clickedCart.Specialty = newMember.Specialty;
            clickedCart.Description = newMember.Description;
            clickedCart.ImgUrl = newMember.ImgUrl;
            _cartDB.SaveChanges();

        }


        #endregion

        #region DELETE
            
        public void DeleteMember(int id)
        {
            TeamCart clickedCart = GetCartById(id);
            _cartDB.carts.Remove(clickedCart);
            _cartDB.SaveChanges();
        } 


        #endregion

    }
}
