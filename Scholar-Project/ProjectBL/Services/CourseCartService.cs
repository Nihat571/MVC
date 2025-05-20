using ProjectDAL.Contexts;
using ProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBL.Services
{
    public class CourseCartService
    {
        private readonly AppDBContext _cartDB;
        public CourseCartService(AppDBContext appDB)
        {
            _cartDB = appDB;
        }

        #region READ

        public List<CourseCart> GetAllCourse()
        {
            return _cartDB.carts.ToList();
        }

        public CourseCart GetCourseById(int id) 
        {
            CourseCart? foundedCart = _cartDB.carts.Find(id);
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

        #region CREATE

        public void AddCourse(CourseCart newCourse)
        {
            _cartDB.carts.Add(newCourse);
            _cartDB.SaveChanges();
        }


        #endregion

        #region DELETE

        public void DeleteCourse(int id)
        {
            CourseCart clickedCourse = GetCourseById(id);
            _cartDB.carts.Remove(clickedCourse);
            _cartDB.SaveChanges();
        }

        #endregion

        #region UPDATE

        public void UpdateCourse(int id,CourseCart updatedCourse)
        {
            CourseCart clickedCourse = GetCourseById(id);
            clickedCourse.Name = updatedCourse.Name;
            clickedCourse.Author = updatedCourse.Author;
            clickedCourse.Subject = updatedCourse.Subject;
            clickedCourse.Price = updatedCourse.Price;
            clickedCourse.ImgUrl = updatedCourse.ImgUrl;
            _cartDB.SaveChanges();

        }

        #endregion

    }
}
