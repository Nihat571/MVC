using Charity_Project.Contexts;
using Charity_Project.Models;

namespace Charity_Project.Services
{
    public class CauseCartService
    {
        private readonly CauseCartDBContext _contextDB;
        public CauseCartService()
        {
            _contextDB = new CauseCartDBContext();
        }


        #region CREATE

        public void AddCart(CauseCart newCart) 
        {
        _contextDB.CauseCart.Add(newCart);
            _contextDB.SaveChanges();
        
        }


        #endregion


        #region READ

        public List<CauseCart> ReadCause()
        {
            return _contextDB.CauseCart.ToList();
        }

        public CauseCart ReadCauseCartById(int id)
        {
            CauseCart foundedCart = _contextDB.CauseCart.Find(id);
            if(foundedCart is not null)
            {
                return foundedCart;
            }
            else
            {
                throw new Exception("DATA NOT FOUND");
            }
        }

        #endregion

        #region UPDATE

        public void UpdateCart(int id,CauseCart updatedCart) 
        {
            CauseCart? foundedCart = _contextDB.CauseCart.Find(id);
            if (foundedCart is not null)
            {
                foundedCart.Name = updatedCart.Name;
                foundedCart.Description = updatedCart.Description;
                foundedCart.RaisedNumber = updatedCart.RaisedNumber;
                foundedCart.GoalNUmber = updatedCart.GoalNUmber;
                foundedCart.ImgUrl = updatedCart.ImgUrl;
                _contextDB.SaveChanges();
            }
            else
            {
                throw new Exception("DATA NOT FOUND");
            }
        }

        #endregion



        #region DELETE
        public void DeleteCauseCart(int id)
        {
            CauseCart? foundedCart = _contextDB.CauseCart.Find(id);
            if (foundedCart is not null)
            {
                _contextDB.CauseCart.Remove(foundedCart);
                _contextDB.SaveChanges();
            }
            else
            {
                throw new Exception("DATA NOT FOUND");
            }
        }
        #endregion

    }
}
